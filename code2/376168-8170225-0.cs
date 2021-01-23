            this.dgvDeskTrades.MouseDown += dgvDeskTrades_MouseDown;
            this.dgvDeskTrades.MouseMove += dgvDeskTrades_MouseMove;
            this.dgvDeskTrades.MouseUp += dgvDeskTrades_MouseUp;
        private int colResizing = -1;
        private int origWidth;
        private int mouseX;
        private void dgvDeskTrades_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = this.dgvDeskTrades.HitTest(e.X, e.Y);
            if (hit.Type != DataGridViewHitTestType.ColumnHeader) return;
            if (Cursor.Current != Cursors.SizeWE) return;
            this.colResizing = hit.ColumnIndex;
            this.origWidth = this.dgvDeskTrades.Columns[this.colResizing].Width;
            this.mouseX = e.X;
        }
        private void dgvDeskTrades_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.colResizing == -1) return;
            this.dgvDeskTrades.Columns[this.colResizing].Width = Math.Max(0, this.origWidth + (e.X - this.mouseX));
            this.toolTip.Show("Width: " + this.dgvDeskTrades.Columns[this.colResizing].Width, this, e.X, e.Y);
        }
        private void dgvDeskTrades_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.colResizing == -1) return;
            this.toolTip.Hide(this);
            this.colResizing = -1;
        }
