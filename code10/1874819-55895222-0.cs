    String amount = "";
    int sum = 0;
            
    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
     {
        amount = dataGridView1.Rows[i].Cells[1].Value.ToString(); //adjust column yourself
        sum += Convert.ToInt32(amount.Replace(@"$", ""));
     }
