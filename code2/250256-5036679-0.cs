    public void SetMinWidths(object source, EventArgs e )
            {
                foreach (var column in Griddy.Columns)
                {
                    column.MinWidth = column.ActualWidth;
                    column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                }
            }
