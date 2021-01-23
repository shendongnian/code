class Helper
    {
        public void disableMultiWindow(Form MdiParent, string formName)
        {
            FormCollection fc = Application.OpenForms;
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == formName)
                    {
                        form.BringToFront();
                        return;
                    }
                }
                Assembly thisAssembly = Assembly.GetExecutingAssembly();
                Type typeToCreate = thisAssembly.GetTypes().Where(t => t.Name == formName).First();
                Form myProgram = (Form)Activator.CreateInstance(typeToCreate);
                myProgram.MdiParent = MdiParent;
                myProgram.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
