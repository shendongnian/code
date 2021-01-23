    class Parent
    {
        KeyEventHandler KeyDownHandler;
    
        public Parent()
        {
            KeyDownHandler = new KeyEventHandler(form_TextBoxKeyDown);
        }
    
        void SetChildForm(Child form)
        {
            form.TextBoxKeyDown += KeyDownHandler;
        }
    
        void RemoveChildForm(Child form)
        {
            form.TextBoxKeyDown -= KeyDownHandler;
        }
    
        void form_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
    
                        break;
                    case Keys.X:
    
                        break;
                    case Keys.V:
    
                        break;
                }
            }
        }
    }
    
    class Child
    {
        TextBox txtBox;
    
        public event KeyEventHandler TextBoxKeyDown;
    
        internal Child()
        {
            txtBox.KeyDown += new KeyEventHandler(txtBox_KeyDown);
        }
    
        void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextBoxKeyDown != null)
                TextBoxKeyDown(sender, e);
        }
    }
