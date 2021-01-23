     foreach (DataGridViewRow row in dgv_labelprint.Rows)
                {
                    
                    if (value.Value == null)
                    {
                        
                    }
                    else if ((Boolean)((DataGridViewCheckBoxCell)row.Cells["CheckBox"]).FormattedValue)
                    {
                        //Come inside if the checkbox is checked
                        //Do something if checked
                    }
                    
                }
