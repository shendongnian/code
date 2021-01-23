    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < listBox1.Items.Count ; i++)
        {
            char[] temp = listBox1.Items[i].ToString().ToCharArray() ;
            char[] temp1 = textBox1.Text.Trim().ToCharArray();
            for (int j = 0; j < temp1.Length ; j++)
            {
                if (temp1[j] != temp[j])
                {
                    listBox1.Items.RemoveAt(i);
                    i = i - 1; // reset index to point to next record otherwise you will skip one
                }
                       
            }
        }
    }
