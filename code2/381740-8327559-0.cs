            DataTable chartTable = new DataTable("Table1");
            // Add two columns to the table.
            chartTable.Columns.Add("Names", typeof(string));
            chartTable.Columns.Add("Value", typeof(Int32));
            chartTable.Rows.Add("Below 50", 10);
            chartTable.Rows.Add("Between 50-100", 10);
            chartTable.Rows.Add("Between 100-200", 10);
            chartTable.Rows.Add("Greater than 200", 10);
            Series series1 = new Series("Series1", ViewType.Pie3D);
            //chartControl1.Series.Clear();
            chartControl2.Series.Add(series1);
            series1.DataSource = chartTable;
            series1.ArgumentScaleType = ScaleType.Qualitative;
            series1.ArgumentDataMember = "names";
            series1.ValueScaleType = ScaleType.Numerical;
            series1.ValueDataMembers.AddRange(new string[] { "Value" });
            //((Pie3DSeriesView)series1.View). = true;
            //((pie)chartControl2.Diagram).AxisY.Visible = false;
            chartControl2.Legend.Visible = false;
