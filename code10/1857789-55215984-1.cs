     try
            {
                var table = new DataTable();
                table.Columns.Add("Year", typeof(int));
                table.Columns.Add("Population", typeof(long));
                table.Columns.Add("Lbl");
    
                using (SPSite site = new SPSite(YourSiteUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList _bugetlist = web.Lists["YearTotal"];
                        foreach (SPListItem _item1 in _bugetlist.Items)
                        {
                            var row = table.NewRow();
                            row["Year"] = Convert.ToInt16(_item1["Year"]);
                            row["Population"] = Convert.ToInt16(_item1["Population"]);
                            table.Rows.Add(row);
                        }
                    }
                }
                Chart1.ChartAreas["ChartArea1"].AxisY.Title = "Population";
                Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Years";
    
    
                Chart1.DataSource = table;
                Chart1.DataBind();
