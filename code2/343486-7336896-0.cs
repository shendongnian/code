        protected override void OnShown(EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                for (int i = 0; i < this.dataGridView1.SelectedCells.Count; i++)
                    this.dataGridView1.SelectedCells[i].Selected = false;
            }
        }
