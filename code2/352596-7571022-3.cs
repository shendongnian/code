    protected void Page_Load(object sender, EventArgs e)
    {
        SemanticCheckBoxList resourceValue = new SemanticCheckBoxList();
        resourceValue.ID = "ResourceValue";
        ResourceValuesPlaceHolder.Controls.Add(resourceValue);
        if (resourceValue.Items.Count == 0)
        {
            PopulateResources();
            MarkSelectedResources();
        }
    }
    private void PopulateResources()
    {
        foreach (Resource res in GetResources(Type))
        {
            ResourceValue.Items.Add(new ListItem(res.Text, SerializeResourceKey(res.Key)));
        }
    }
    private IEnumerable<Resource> GetResources(string resType)
    {
        List<Resource> availableResources = new List<Resource>();
        IEnumerable<Resource> resources = Owner.Resources.GetResourcesByType(resType);
        foreach (Resource res in resources)
        {
            if (IncludeResource(res))
            {
                availableResources.Add(res);
            }
        }
        return availableResources;
    }
    private bool IncludeResource(Resource res)
    {
        return res.Available || ResourceIsInUse(res);
    }
    private string SerializeResourceKey(object key)
    {
        LosFormatter output = new LosFormatter();
        StringWriter writer = new StringWriter();
        output.Serialize(writer, key);
        return writer.ToString();
    }
    private void MarkSelectedResources()
    {
        foreach (Resource res in Appointment.Resources.GetResourcesByType(Type))
        {
            ResourceValue.Items.FindByValue(SerializeResourceKey(res.Key)).Selected = true;
        }
    }
