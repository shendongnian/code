    private void button5_Click(object sender, EventArgs e)
            {
                if (this.DGINV.DataSource != null)
                {
                    this.DGINV.DataSource = null;
                }
                else
                {
                    this.DGINV.Rows.Clear();
                }
            }
