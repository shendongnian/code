        private void Form1_Load(object sender, EventArgs e)
        {
            //Create a new instance of DataGridView(WindowsForm) control.
            DataGridView dataGridView1 = new DataGridView();
            this.Controls.Add(dataGridView1);
            //Customize output.
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.AutoSize = true;
            //Set datasource.
            dataGridView1.DataSource = GetData();
            //Export as image.
            Bitmap bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(Point.Empty, dataGridView1.Size));
            bitmap.Save("sample.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Dispose();
            System.Diagnostics.Process.Start("sample.jpg");
        }
        /// <summary>
        /// Helper method.
        /// </summary>
        DataTable GetData()
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < 2; i++)
                dt.Columns.Add(string.Format("Column{0}", i));
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    dt.Rows.Add(new string[] { "X", "Y" });
                }
            }
            return dt;
        }
