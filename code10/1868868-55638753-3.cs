    private class PictureBoxHandler : IDisposable
    {
        public PictureBoxHandler(IEnumerable<PictureBox> items) {
            this.Items = new List<PictureBox>();
            this.Items.AddRange(items);
            this.Items.ForEach(i => i.Click += this.ItemSelected);
        }
        private List<PictureBox> Items { get; }
        private PictureBox Selected { get; set; } = null;
        protected internal void ItemSelected(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.Fixed3D;
            if (this.Selected != null) this.Selected.BorderStyle = BorderStyle.None;
            this.Selected = (PictureBox)sender;
        }
        public void Dispose() => this.Dispose(true);
        public void Dispose(bool disposing)
        {
            if (disposing) {
                if (this.Items is null) return;
                this.Items.ForEach(i => i.Click -= this.ItemSelected);
                for (int i = this.Items.Count - 1; i >= 0; i--) {
                    this.Items[i].Dispose();
                }
                this.Items.Clear();
            }
        }
    }
