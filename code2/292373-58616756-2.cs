    //using System.IO; 
    private void GetDirectories()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("direction",typeof(string));
        try
        {
            string[] dirs = Directory.GetDirectories(@"yourpath", "*", SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {
                dt.Rows.Add(dir);
            }
            if (dirs.Length <= 0)
            {
                 lbl.text="your message"
    
            }
    
           rpt.DataSource = dt; //your repeater 
           rpt.DataBind(); //your repeater 
        }
        catch (Exception e)
        {
           lbl.text="your message"//print message assign it to label
        }
    }
