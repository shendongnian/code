            int myCount;
            try { myCount = this.gridView2.Columns.Count; }
            catch { myCount = 0; }
            for (int j = 0; j < myCount; j++)
            {
                this.gridView2.Columns[j].Visible = false;
            }
