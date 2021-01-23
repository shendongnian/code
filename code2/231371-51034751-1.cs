        void frmMain_Load(object sender, EventArgs e) {
            this.DataGridView1.Rows.Clear();
            this.DataGridView1.Rows.Add(this.PictureBox1.Image);
        }
        void Timer1_Tick(object sender, EventArgs e) {
            if (this.DataGridView1.Rows.Count > 0) {
                this.DataGridView1.Rows[0].Cells[0].Value = this.PictureBox1.Image;
                this.DataGridView1.InvalidateCell(0, 0);
            }
        }
        void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
            e.Graphics.DrawLine(new Pen(SystemColors.ActiveBorder), 0, 0, 1, 1);
        }
