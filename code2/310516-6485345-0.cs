    List<UIElement> list = new List<UIElement>();
    
                GetAllControl("someCanvas", list);
    
            private void GetAllControl(Canvas c , List<UIElement> list)
            {
                foreach (Control control in c.Controls)
                {
                    list.Add(control);
    
                    if (control.Controls.Count > 0)
                        GetAllControl(control , list);
                }
            }
