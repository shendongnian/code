    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString();
                foreach(char theChar in textBox1.Text)
                {
                    if(item.Contains(theChar))
                    {
                        //remove the item, consider the next list box item
                        //the new list box item index would still be i
                        listBox1.Items.Remove(item);
                        i--;
                        break;
                    }
                }
            }
        }
