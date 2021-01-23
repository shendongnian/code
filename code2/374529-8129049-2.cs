           List<String> temp = new List<string>();
            string strControlType;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.HasControls() == true)
                {
                    foreach (Control subctrl in ctrl.Controls)
                    {
                        CheckBox TControl = subctrl as CheckBox;
                        strControlType = Convert.ToString(subctrl.GetType());
                        if (strControlType == "System.Web.UI.WebControls.CheckBox" && TControl.Checked)
                        {
                            temp.Add(TControl.Text);
                        }
                    }
                }
            }
