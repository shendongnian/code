            string startdatetime = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Start Date"].Value);
            string enddatetime = Convert.ToString(dataGridView1.SelectedRows[0].Cells["End Date"].Value);
    
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (string.IsNullOrEmpty(cell.Value as string))
                    {
                        string txtQuery = "insert into CertDB(DateAttended, EndDate) values ('" + startdatetime + "', '" + enddatetime + "')";
                        ExecuteQuery(txtQuery);
                    }
                    else
                    {
                        string startdate = string.IsNullOrWhiteSpace(startdatetime) ? DBNull.Value : Convert.ToDateTime(startdatetime).ToString("dd/M/yyyy");
            string enddate = string.IsNullOrWhiteSpace(enddatetime) : DBNull.Value : Convert.ToDateTime(enddatetime).ToString("dd/M/yyyy");
            string expiry = string.IsNullOrWhiteSpace(expirytime) ? DBNull.Value : Convert.ToDateTime(expirytime).ToString("dd/M/yyyy");
            string txtQuery = "insert into CertDB(DateAttended, EndDate) values ('" + startdate + "', '" + enddate + "')";
            ExecuteQuery(txtQuery);
                    }
                }
            }
