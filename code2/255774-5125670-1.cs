        public class Form1 : Form
        {
            public Form1()
            {
                // Add a handler for the EditingControlShowing event
                myDGV.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(myDGV_EditingControlShowing);
            }
            private void myDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                // Ensure that the editing control is a TextBox
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    // Remove an existing event handler, if present, to avoid adding
                    // multiple handler when the editing control is reused
                    txt.KeyPress -= new KeyPressEventHandler(txt_KeyPress);
                    // Add a handler for the TextBox's KeyPress event
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                }
            }
            private void txt_KeyPress(object sender, KeyPressEventArgs e)
            {
                // Write your validation code here
                // ...
                MessageBox.Show(e.KeyChar.ToString());
            }
        }
