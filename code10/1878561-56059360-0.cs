    int sumphre = 0;
    for (int i =0; i< dataGridViewWhouse.Rows.Count; i++)
    {
    //here is the problem
    string outString = dataGridViewWhouse.Rows[dataGridViewWhouse.Rows[i].Index]
                        .Cells[6]
                        .Value
                        .ToString();
    int length = outString.Length;
    if (length == 4)
    {
        sumphre += Convert.ToInt32(dataGridViewWhouse.Rows[i].Cells[7].Value);
    }
    }
    label4.Text = sumphre.ToString();
