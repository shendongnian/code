    private void SetComboBoxItemssource()
        {
            PrinterTypes = database.GetPrinterTypes();
            DataGridComboBoxColumn cmbColumn = null;
            foreach (DataGridColumn column in dtaPrinters.Columns)
            {
                if ((cmbColumn = column as DataGridComboBoxColumn) != null)
                    break;
            }
            if (cmbColumn == null)
                return;
            cmbColumn.ItemsSource = PrinterTypes;
        }
