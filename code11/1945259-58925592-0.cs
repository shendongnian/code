        public void AddImages(int row, int col)
        {
            TableLayoutPanel tlp = new TableLayoutPanel();
            int prow = 100 / row, pcol = 100 / col;
            for(var i=0;i<row;i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, prow));
            }
            for(var i=0;i<col;i++)
            {
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, pcol));
            }
            //modify the add logic according to your requirement.
            tlp.Controls.Add(new Panel() { Dock = DockStyle.Fill }, 1, 1);  
            //todo...
            this.Controls.Add(tlp);         
        }
