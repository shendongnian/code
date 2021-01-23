     foreach (Control group in this.Controls)             //Control combo in this.Controls)
                {
                    if (group.GetType().Name == "GroupBox")  //(con is ComboBox)
                    {
                        foreach (Control con in group.Controls)
                        {
                            if (con.GetType().Name == "ComboBox")
                            {
                                
                                ComboBox combo = (ComboBox)con;
                                _dtStaff=new DataTable();
                                  _dtStaff = _staff.getStaffList();
                                combo.DataSource = _dtStaff;
                                combo.DisplayMember = _dtStaff.Columns[1].ToString();
                                combo.ValueMember = _dtStaff.Columns[0].ToString();
                            }
                        }
                    }
                }
