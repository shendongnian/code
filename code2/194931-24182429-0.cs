    private List<Control> GetAllNestedUserControl(Control ph)
        {
            List<Control> Get = new List<Control>();
            foreach (var control in ph.Controls)
            {
                if (control is UserControl)
                {
                    UserControl uc = control as UserControl;
                    if (uc.HasControls())
                    {
                       Get =  GetAllNestedUserControl(uc);
                      
                    }
                }
                else
                {
                    Control c = (Control)control;
                    if (!(control is LiteralControl))
                    {
                         Get.Add(c);
                    }
                }
            }
            return Get;
        }
