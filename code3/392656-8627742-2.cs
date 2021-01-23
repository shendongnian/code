    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < listBox1.Items.Count ; i++)
        {
            for (int j = 0; j < textBox1.Text.Length  ; j++)
            {
                if (textBox1.Text[j] != listBox1.Items[i].ToString()[j])
                {
                    if (i < 0) break;
                    listBox1.Items.RemoveAt(i);
                    i = i - 1; // reset index to point to next record otherwise you will skip one
                }
                        
            }
        }
    }
