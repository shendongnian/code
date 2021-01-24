    public Dictionary<string, bool> Save(params CheckBox[] check)
    {
        Dictionary<string, bool> result = new Dictionary<string, bool>();
        foreach (CheckBox item in check)
            result.Add(item.Name, item.Checked);
        return result;
    }
    public void Apply(Dictionary<string, bool> savedResults)
    {
        foreach (var item in savedResults)
        {
            var check = this.Controls[item.Key];
            if(check != null && check.GetType().ToString() == "System.Windows.Forms.CheckBox")
            {
                ((CheckBox)check).Checked = item.Value;
            }
        }
    }
