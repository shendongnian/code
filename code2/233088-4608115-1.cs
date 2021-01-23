        public static void writetoStatus(Form frm, string text)
        {
            TextBox tb = new TextBox();
            tb.Text = text;
            frm.Controls.Add(tb);
        }
        
        // and then later use it like: 
        writetoStatus(myForm, text);
