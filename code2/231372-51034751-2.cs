        void frmMain_Load(object sender, EventArgs e) {
            DataGridView1.Rows.Clear();
            DataGridView1.Rows.Add(PictureBox1.Image);
        }
        void Timer1_Tick(object sender, EventArgs e) {
            if (DataGridView1.Rows.Count > 0) {
                DataGridView1.Rows[0].Cells[0].Value = PictureBox1.Image;
                DataGridView1.InvalidateCell(0, 0);
            }
        }
        void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
            e.Graphics.DrawLine(new Pen(SystemColors.ActiveBorder), 0, 0, 1, 1);
        }
