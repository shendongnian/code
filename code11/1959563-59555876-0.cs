     foreach (Control c in panel1.Controls)// all checkboxes in a panel
      {
          int i = 1;
          var val = Properties.Settings.Default.Properties["Setting" + i.ToString()];
                 if (c is CheckBox)
                    {
                      if ((!((CheckBox)c).Checked))
                        {
                          ((CheckBox)c).Checked = Convert.ToBoolean(val.DefaultValue);
                                ((CheckBox)c).Click += delegate
                                {
                                    val.DefaultValue = ((CheckBox)c).Checked;
                                    Properties.Settings.Default.Save();
                                };
                        }
                      
                     }
                   i++;           
       }
