    protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {       
            var descLabel= e.Item.FindControl("RptIDLabel") as Label;
            var data = (MyDataType)e.Item.DataItem; 
            if (data.RptID == "SomeString")
            {
               descLabel.Text = "Pass";
            }
            ...       
    }
