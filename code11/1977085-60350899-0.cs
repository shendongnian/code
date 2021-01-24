        //filling the Coloumns
        dataGridView1.Rows.Clear();
        dataGridView1.Columns.Clear();
        dataGridView1.Columns.Add("name", "Column1");
        dataGridView1.Columns.Add("budgetedhr", "Column2");
        dataGridView1.Columns.Add("spenthr", "Column3");
        // filling in Rows with some data
        dataGridView1.Rows.Add("Jhon", 21, 23);
        dataGridView1.Rows.Add("Nicol", 31, 2);
        dataGridView1.Rows.Add("Matteo", 23, 41);
        // Now we can set up the Chart:
        List<Color> colors = new List<Color> { Color.Green, Color.Red};
        chart1.Series.Clear();
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            Series S = chart1.Series.Add(dataGridView1[0, i].Value.ToString());
            S.ChartType = SeriesChartType.Column;
            S.Color = colors[i];
        }
        // and fill in all the values from the dgv to the chart:
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            for (int j = 1; j < dataGridView1.Columns.Count; j++)
            {
                int p = chart1.Series[i].Points.AddXY(dataGridView1.Columns[j].HeaderText, dataGridView1[j, i].Value);
            }
        }
