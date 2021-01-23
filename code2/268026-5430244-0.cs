    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                if (e.Control is TextBox)
                {
                    (e.Control as TextBox).KeyDown += new KeyEventHandler(Form1_KeyDown);
                    //add as you require
                }
            }
    
            void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                // your code here
            }
