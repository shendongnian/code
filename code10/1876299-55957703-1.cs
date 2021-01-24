                foreach (Form discoveredForm in Application.OpenForms)
            {
                if (discoveredForm.Name != "MainForm")
                {
                    discoveredForm.Hide();
                    try
                    {
                        var S = (Form2)discoveredForm;
                        S.isRenamed = True;
                    }
                    catch
                    {
                    }
                }
            }
