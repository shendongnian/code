            int displayIndex = 0;
            for (int i = 0; i < columns.Count; i++)
            {
                columnOrder.Add(new ColumnOrderItem
                {
                    ColumnIndex = i,
                    DisplayIndex = displayIndex;
                    Width = columns[i].Width
                });
                if (columns[i].Visible) displayIndex++;
            }
