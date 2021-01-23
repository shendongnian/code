        private void button11_Click(object sender, EventArgs e)
      {
                DateTime PD = new DateTime(DateTime.Today);
                saveFileDialog1.FileName = PD.ToString("yyyy-MM-dd");
                saveFileDialog1.Filter = " files|*.bak;*.BAK";
                saveFileDialog1.InitialDirectory = "d:";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string path = string.Empty;
                        path = saveFileDialog1.FileName;
    
                        path = path.Replace("\\", "//");
                        bool bBackUpStatus = true;
                        Cursor.Current = Cursors.WaitCursor;
                        if (System.IO.File.Exists(path))
                        {
                            if (MessageBox.Show(@"do you want a new one?", "the file is existing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                System.IO.File.Delete(path);
                            }
                            else
                                bBackUpStatus = false;
                        }
                        if (bBackUpStatus)
                        {
                            //Connect to DB
                            SqlConnection Conn = new SqlConnection("Server=(local); Data Source=LocalHost; DataBase=Exchange; UID=sa; Pwd=sql");
                            //string con = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirector  y|\SRVCARD.mdf;Integrated Security=True;User Instance=True";
                            if (Conn.State.ToString() == "Open")
                            {
                                Conn.Close();
                            }
                            Conn.Open();
                            SqlCommand command = new SqlCommand(@"backup database Exchange To Disk='" + path + "' with stats=10", Conn);
                            command.ExecuteNonQuery();
                            Conn.Close();
                            MessageBox.Show("Backup successfully", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("please change the path");
                        //MessageBox.Show(ex.ToString());
                    }
                }
