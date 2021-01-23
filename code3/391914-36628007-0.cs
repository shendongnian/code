    private void button1_Click(object sender, EventArgs e)
        {
            string google = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\History";
            string fileName = DateTime.Now.Ticks.ToString();
            File.Copy(google, Application.StartupPath + "\\" + fileName);
            using (SQLiteConnection con = new SQLiteConnection("DataSource = " + Application.StartupPath + "\\" + fileName + ";Versio=3;New=False;Compress=True;"))
            {
                con.Open();
                //SQLiteDataAdapter da = new SQLiteDataAdapter("select url,title,visit_count,last_visit_time from urls order by last_visit_time desc", con);
                SQLiteDataAdapter da = new SQLiteDataAdapter("select * from urls order by last_visit_time desc", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            try // File already open error is skipped
            {
              if (File.Exists(Application.StartupPath + "\\" + fileName))
                 File.Delete(Application.StartupPath + "\\" + fileName);
            }
            catch (Exception)
            {
            }
        }
