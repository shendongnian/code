            public Form1()
            {
                InitializeComponent();
                dt.Columns.Add("Product", typeof(string));
                dt.Columns.Add("Factory", typeof(string));
                dt.Columns.Add("Price", typeof(int));
                dt.Columns.Add("Note", typeof(string));
                dt.Rows.Add("ProductA", "Factory1", "5000", "Note1");
                dt.Rows.Add("ProductB", "Factory1", "6000", "Note1");
                dt.Rows.Add("ProductC", "Factory2", "6000", "Note2");
                dt.Rows.Add("ProductD", "Factory3", "7000", "Note2");
                dt.Rows.Add("ProductE", "Factory3", "7000", "Note3");
    
                this.dataGridView1.DataSource = dt;
            }
           
            DataTable dt = new DataTable();
            private void Form1_Load(object sender, EventArgs e)
            {
                dataGridView1.AutoGenerateColumns = false;
            }
                    
            private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                //Offsets to adjust the position of the merged Header.
                int heightOffset = -5;
                int widthOffset = -2;
                int xOffset = 0;
                int yOffset = 4;
    
                //Index of Header column from where the merging will start.
                int columnIndex = 2;
    
                //Number of Header columns to be merged.
                int columnCount = 2;
    
                //Get the position of the Header Cell.
                Rectangle headerCellRectangle = dataGridView1.GetCellDisplayRectangle(columnIndex, 0, true);
    
                //X coordinate of the merged Header Column.
                int xCord = headerCellRectangle.Location.X + xOffset;
    
                //Y coordinate of the merged Header Column.
                int yCord = headerCellRectangle.Location.Y - headerCellRectangle.Height + yOffset;
    
                //Calculate Width of merged Header Column by adding the widths of all Columns to be merged.
                int mergedHeaderWidth = dataGridView1.Columns[columnIndex].Width + dataGridView1.Columns[columnIndex + columnCount - 1].Width + widthOffset;
    
                //Generate the merged Header Column Rectangle.
                Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, headerCellRectangle.Height + heightOffset);
    
                //Draw the merged Header Column Rectangle.
                e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect);
    
                //Draw the merged Header Column Text.
                e.Graphics.DrawString("Price/Note", dataGridView1.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, xCord + 2, yCord + 3);
            }
    
            private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (e.RowIndex == 0)
                    return;
                if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
