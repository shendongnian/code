           // above code hasn't changed
            Single percHeight = ((Single)1 / (Single)tableLayoutPanel_TopView.RowStyles.Count) * 100;
            Single percWidth = ((Single)1 / (Single)tableLayoutPanel_TopView.ColumnStyles.Count) * 100;
            tableLayoutPanel_TopView.ColumnStyles.Clear();
            tableLayoutPanel_TopView.RowStyles.Clear();
            for (int x = 0; x < sortedContainers.Width; x++)
            {
                tableLayoutPanel_TopView.ColumnStyles.Add(new ColumnStyle
                {
                    SizeType = SizeType.Percent,
                    Width = percWidth
                });
            }
            for (int y = 0; y < sortedContainers.Length; y++)
            {
                tableLayoutPanel_TopView.RowStyles.Add(new RowStyle
                {
                    SizeType = SizeType.Percent,
                    Height = percHeight
                });
            }
