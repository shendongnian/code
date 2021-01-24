        public int CountObjectsInRows(string idValue)
        {
            int count = 0;
            if (string.IsNullOrEmpty(idValue))
            {
                return count;
            }
            foreach (DataGridViewRow row in this.dataGridEquipamento.SelectedRows)
            {
                if (row.Cells[0].Value.ToString() == idValue)
                {
                    count++;
                }
            }
            return count;
        }
