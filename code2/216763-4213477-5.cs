        private void textBox_Click(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            
            if (textBox != null)
            {
                //Here your have the text of the clicked textbox
                string text = textBox.Text;
                //And here the X and Y position of the clicked textbox
                int ipos = (textBox.Tag as GridIndex).ipos;
                int jpos = (textBox.Tag as GridIndex).jpos;   
            }
        }
