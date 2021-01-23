    List<Control> list = new List<Control>();
    
                GetAllControl(this, list);
    
            private void GetAllControl(Control c , List<Control> list)
            {
                foreach (Control control in c.Controls)
                {
                    list.Add(control);
    
                    if (control.Controls.Count > 0)
                        GetAllControl(control , list);
                }
            }
