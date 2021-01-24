       private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            int index = listBox1.SelectedIndex;
            int indexErrorFix = listBox1.Items.Count;
            if (e.KeyCode == Keys.Up)
            {
                index--;
               
            }
            else if (e.KeyCode == Keys.Down)
            {
                index++;
                
            }
            if (index < indexErrorFix && index >= 0)
            {
                listBox1.SelectedIndex = index;
            }
            else { }
          
            textBox1.SelectionStart = textBox1.Text.Length;
        }
