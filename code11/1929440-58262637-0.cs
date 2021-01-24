    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    
    dt1.Columns.AddRange(new DataColumn[] { new DataColumn(), new DataColumn(), new DataColumn() });
    dt2.Columns.AddRange(new DataColumn[] { new DataColumn(), new DataColumn(), new DataColumn() });
    dt3.Columns.AddRange(new DataColumn[] { new DataColumn(), new DataColumn(), new DataColumn() });
    
    Random rnd = new Random();
    int count = rnd.Next(3, 10);
    
    for(int i =0; i < count; i++)
    {
        dt1.Rows.Add("T1C1R" + i, "T1C2R" + i, "T1C3R" + i);                
    }
    
    count = rnd.Next(3, 10);
    
    for(int i = 0; i < count; i++)
    {
        dt2.Rows.Add("T2C1R" + i, "T2C2R" + i, "T2C3R" + i);
    }
    
    DataTable tmpDt1 = dt1.Rows.Count >= dt2.Rows.Count ? dt1 : dt2;
    DataTable tmpDt2 = tmpDt1 == dt1 ? dt2 : dt1;
    
    for(int i = 0; i < tmpDt1.Rows.Count; i++)
    {
        DataRow dr = dt3.NewRow();
        dr.ItemArray = tmpDt1.Rows[i].ItemArray;
    
        if (i < tmpDt2.Rows.Count)
        {
            dr[0] = dr[0] + ", " + tmpDt2.Rows[i][0];
            dr[1] = dr[1] + ", " + tmpDt2.Rows[i][1];
            dr[2] = dr[2] + ", " + tmpDt2.Rows[i][2];                    
        }
        dt3.Rows.Add(dr);
    }
    dataGridView1.DataSource = dt1;
    dataGridView2.DataSource = dt2;
    dataGridView3.DataSource = dt3;
