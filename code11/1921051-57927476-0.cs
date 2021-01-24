    try
            {
                DateTime date;
                MySqlDataAdapter sda = new MySqlDataAdapter("select Name,Dateofbirth from members where (DATE_FORMAT(Dateofbirth, '%m-%d') >= DATE_FORMAT(NOW(), '%m-%d') and DATE_FORMAT(Dateofbirth, '%m-%d') <= DATE_FORMAT((NOW() + INTERVAL +7 DAY), '%m-%d')) and Branch=@Branch", conn);
                sda.SelectCommand.Parameters.AddWithValue("@Branch", lbladminbranch.Text.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dt.Columns.Add("BirthDay", typeof(string));
                dataGridViewbirthday.DataSource = dt;
                dataGridViewbirthday.ForeColor = Color.Black;
                if (dataGridViewbirthday.Rows.Count > 0)
                {
                   dataGridViewbirthday.Columns["Dateofbirth"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    for (int i = 0; i < dataGridViewbirthday.Rows.Count; i++)
                    { 
                    date = Convert.ToDateTime(dataGridViewbirthday[1, i].Value);
                    String Newdate =Convert.ToString(date.ToString());
                    DateTime birthday = Convert.ToDateTime(date);
                    int day =birthday.Day;
                    int month =birthday.Month;
                    int CurrentYear = Convert.ToInt32(DateTime.Now.Date.Year);
                    String NewDay = day.ToString("00");
                    String NewMonth = month.ToString("00");
                    String Year = CurrentYear.ToString();
                    String FullDate =Year + "/" + NewMonth + "/" + NewDay;
                    DateTime CurrentDate = Convert.ToDateTime(FullDate);
                    foreach(DataGridViewColumn col in dataGridViewbirthday.Columns)
                    {
                            if (col.Name=="BirthDay")
                            {
                                 dataGridViewbirthday["BirthDay", i].Value = CurrentDate.DayOfWeek.ToString();
                                //dataGridViewbirthday.Rows[i].Cells["BirthDay"].Value = CurrentDate.DayOfWeek.ToString();    
                            }   
                    }
                       
                    }
                    dataGridViewbirthday.Sort(dataGridViewbirthday.Columns[2], ListSortDirection.Descending);
                }
                else
                {
                dataGridViewbirthday.DataSource = null;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
