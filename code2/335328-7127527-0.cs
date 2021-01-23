    private void UltraGridEditAfterCellUpdate(object sender, CellEventArgs e)
                {
                    if (e.Cell.Column.PropertyDescriptor.DisplayName.Equals("Amount"))
                    {
                        UltraGridEdit.ActiveRow.Cells["StartDate"].Value = null;
                    }
                }
