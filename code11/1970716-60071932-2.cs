    public void BindCheckBoxList()
    {
        IEnumerable<string> dates=Enumerable.Range(1, 7).Select(p=>DateTime.Now.Date.AddDays(p).ToString("dddd HH:mm:ss"));
            CheckBoxList1.DataSource = dates;  
            CheckBoxList1.DataBind();
    }
