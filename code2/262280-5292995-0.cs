    while (dbReader.Read())
                    {
                        aMember = new Member
                                    (dbReader["FirstName"].ToString(),
                                     dbReader["LastName"].ToString(),
                                     dbReader["StudentId"].ToString(),
                                     dbReader["PhoneNumber"].ToString());
                        // tb1.Text = dbReader["FirstName"].ToString();
                        // tb2.Text = dbReader["LastName"].ToString();
                        // tb1.Text = aMember.X().ToString();
                        //tb2.Text = aMember.Y(aMember.ID).ToString(); 
                        BindingList<Member> comboBoxList = new BindingList<Member>();
                        comboList.Add(aMember)
                       
                    }
 
    comboBox1.DataSource = comboBoxList; 
                            comboBox1.DisplayMember = "FirstName"; 
                            comboBox1.ValueMember = "ID";
                           
