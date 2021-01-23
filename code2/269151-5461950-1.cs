        public byte[] GetData()
        {
            Form form = new Form();
            //Create a new instance of DataGridView(WindowsForm) control.
            DataGridView dataGridView1 = new DataGridView();
            form.Controls.Add(dataGridView1);
            //Customize output.
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.AutoSize = true;
            //Set datasource.
            dataGridView1.DataSource = GetDataTable();
            //Export as image.
            Bitmap bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(Point.Empty, dataGridView1.Size));
            //bitmap.Save("sample.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Dispose();
            form.Dispose();
            return ms.ToArray();
        }
        /// <summary>
        /// Helper method.
        /// </summary>
        DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < 2; i++)
                dt.Columns.Add(string.Format("Column{0}", i));
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    dt.Rows.Add(new string[] { "X1", "Y1" });
                }
            }
            return dt;
        }
