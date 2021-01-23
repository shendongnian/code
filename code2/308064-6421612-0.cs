     List<Control> list = new List<Control>();
    
                GetAllControl(this, list);
    
                foreach (Control control in list)
                {
                    if (control.GetType() == typeof(Button))
                    {
                        //all btn
                    }
                }
           
            private void GetAllControl(Control c , List<Control> list)
            {
                foreach (Control control in c.Controls)
                {
                    list.Add(control);
    
                    if (control.GetType() == typeof(Panel))
                        GetAllControl(control , list);
                }
            }
