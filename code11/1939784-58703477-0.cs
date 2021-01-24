     private void button1_Click(object sender, EventArgs e)
            {
                SHDocVw.InternetExplorer ie = null;
                ie = new SHDocVw.InternetExplorer();
                ie.Navigate("www.microsoft.com", Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                ie.Visible = true;
            }
