    private void Voting_Editor_Tool_Load(object sender, EventArgs e)
            {
                GetData();
            }
            public void GetData()
            {
                try
                {
                    now = DateTime.Now;
                    String time_date = now.ToString();
                    using (SqlConnection myConnection = new SqlConnection(@"User ID=sa;Password=password123;Initial Catalog=dishtv;Persist Security Info=True;Data Source=ENMEDIA-EA6278E\ENMEDIA"))
                    {
                        //myConnection.Open();
                        //SqlDataReader dr = new SqlCommand("SELECT question_text,question_id FROM otvtbl_question ", myConnection).ExecuteReader();
    
                        // listView1.Columns.Clear();
                        listView1.Items.Clear();
    
                        myConnection.Open();
                        String MyString1 = string.Format("SELECT question_id,question_text,start_time,end_time,status,repeat FROM otvtbl_question");
    
                        com = myConnection.CreateCommand();
                        com.CommandText = MyString1;
    
                        using (IDataReader dr = com.ExecuteReader())
                        {
                            ListViewItem itmX;
                            //Adding the Items To The Each Column
                            while (dr.Read())
                            {
                                itmX = new ListViewItem();
                                itmX.Text = dr.GetValue(0).ToString();
                                var word = itmX.Text;
                                for (int i = 1; i < 6; i++)
                                {
                                    itmX.SubItems.Add(dr.GetValue(i).ToString());
                                }
                                if (dr.GetDateTime(2) < now && dr.GetDateTime(3) > now)
                                {
                                    itmX.SubItems[4].Text = "Broadcasting";
                                }
                                else if (dr.GetDateTime(3) < now)
                                {
                                    string a = Convert.toString(dr.GetDateTime(3));
                                    itmX.SubItems[4].Text = "Expired";
                                    String broadcast = string.Format("UPDATE otvtbl_question SET             status='EXPIRED' where start_time='{6}'", a);
                                    //Execute the SqlCommand
                                    com = new SqlCommand(broadcast, myConnection);
                                    com.ExecuteNonQuery();
                                }
                                else
                                {
                                    itmX.SubItems[4].Text = "Not Expired";
                                }
                                listView1.Items.Add(itmX);
                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    //Error Message While Fetching
                    MessageBox.Show("Error While Fetching the data From the DataBase" + ex);
                }
    
                finally
                {
                }
            }
