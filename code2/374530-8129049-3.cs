            List<String> temp = new List<string>();
            foreach (Control ctrl in TabContainer1.Controls)
            {
                if (ctrl.HasControls())
                {
                    foreach (Control subctrl in ctrl.Controls)
                    {
                        CheckBox TControl = subctrl as CheckBox; 
                        if (TControl != null && TControl.Checked) 
                        {
                            temp.Add(TControl.Text);
                        }                         
                    }
                }
            }
