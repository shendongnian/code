    MobileSalesChart.Series["Apple"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Apple"].ToString().Trim()));
    MobileSalesChart.Series["Nokia"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Nokia"].ToString().Trim()));
    MobileSalesChart.Series["Samsung"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Samsung"].ToString().Trim()));
    MobileSalesChart.Series["Sony"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Sony"].ToString().Trim()));
    MobileSalesChart.Series["Motorola"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Motorola"].ToString().Trim()));
    MobileSalesChart.Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["Year"].ToString().Trim();
