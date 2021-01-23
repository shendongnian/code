        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }
            return null;
        }
    private void Submit_button_Click(object sender, RoutedEventArgs e)
    {
        string variable = variable_textBox.Text;
        if (variable.Length >= 1 && variable.Length <= 6)
        {
            //get some data from db
        }
        else
        {
            ChildWindow frm = null;
                if ((frm = (ChildWindow)IsFormAlreadyOpen(typeof(ChildWindow))) == null)
                {
                    frm = new ChildWindow();
                    frm.Show();
                }
                else
                { }
        }
    }
