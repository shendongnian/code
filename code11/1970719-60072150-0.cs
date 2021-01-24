    public void BindCheckBoxListWithNextSevenDays()
    {
        DateTime today = DateTime.Now;
        DataTable dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("date", typeof(string));
        for(int i = 1; i <= 7; i++)
        {
            dt.Rows.Add(i, today.AddDays(i).ToString("dddd yyyy-MM-dd")); // (dddd yyyy-MM-dd) will return the date in following format (Wednesday 2020/02-05)
        }
        CheckBoxList1.DataSource = dt;  
        CheckBoxList1.DataBind();
    }
