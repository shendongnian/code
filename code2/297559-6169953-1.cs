    private void AddItem(DateTime dateTime)
    {
        dropDownList.Items.Add(new ListItem(dateTime.ToString("MMMM"), dateTime.ToString("O")));
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AddItem(dateTime1);
        AddItem(dateTime2);
        AddItem(dateTime3);
        AddItem(dateTime4);
    }
