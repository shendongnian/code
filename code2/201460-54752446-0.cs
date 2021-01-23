      public static bool isFormOpen(Form formm)
        {
           
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.Name == formm.Name)
                {
                    return true;
                }
            }
            return false;
        }
