        DateTimePicker dtp = new DateTimePicker();
        Rectangle rectangle;
        public Form1()
        {
            InitializeComponent();
            dgv.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5: // Column index of needed dateTimePicker cell
                    rectangle = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                    dtp.Size = new Size(rectangle.Width, rectangle.Height); //  
                    dtp.Location = new Point(rectangle.X, rectangle.Y); //  
                    dtp.Visible = true;
                    break;
            }
        }
        private void dtp_TextChange(object sender, EventArgs e)
        {
            dgv.CurrentCell.Value = dtp.Text.ToString();
        }
        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }
        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }
