    private void AddButton_Click(object sender, EventArgs e)
    {
        decimal sum = 0;  //Set sum = 0  by default
        listBox2.Items.Add(TextBox1.Text);
        TextBox1.Text = "";
    
        for (int i = 0; i < listBox2.Items.Count; i++)
        {
            sum += Convert.ToDecimal(listBox2.Items[i].ToString());
        }
    
        Label1.Text = sum.ToString();
    }
