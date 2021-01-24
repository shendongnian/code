        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Select * From [" + cboDTA_TBL.Text + "];";
            DataTable dtTAB1 = new DataTable();
            using (SqlConnection conPRJ_NET = new SqlConnection("Your connection string"))
            {
                using (SqlDataAdapter adpPRJ = new SqlDataAdapter(query, conPRJ_NET))
                {
                    adpPRJ.Fill(dtTAB1);
                }
            }
            dgFIN_TAB.DataSource = dtTAB1;
        }
