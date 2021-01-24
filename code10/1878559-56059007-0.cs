    int sumphre = 0;
    
    for (int i =0; i< dataGridViewWhouse.Rows.Count; i++)
    {
        var row = dataGridViewWhouse.Rows[i];
        string outString = row.Cells[6].Value.ToString();
    
        int length = outString.Length;
        if (length == 4)
        {
            sumphre += Convert.ToInt32(row.Cells[7].Value);
        }
    }
    
    label4.Text = sumphre.ToString();
