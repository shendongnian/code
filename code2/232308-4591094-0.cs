    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                if (e.Control.GetType() == typeof(DataGridViewTextBoxEditingControl))
                {
                    TextBox txt = (TextBox)e.Control;
                    txt.PasswordChar = '*';
                }
            }
