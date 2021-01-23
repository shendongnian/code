        private RelayCommand _resultsGridCopyCommand;
        public RelayCommand ResultsGridCopyCommand {
            get {
                if (_resultsGridCopyCommand == null) {
                    _resultsGridCopyCommand = new RelayCommand(this.CopyFromResultsGrid);
                }
                return _resultsGridCopyCommand;
            }
        }
        private void CopyFromResultsGrid(object grid) {
            var resultsGrid = (DataGrid)grid;
            ApplicationCommands.Copy.Execute(null, resultsGrid);
            var oldData = Clipboard.GetDataObject();
            var newData = new DataObject();
            foreach (var format in oldData.GetFormats()) {
                if (format.Equals("UnicodeText") || format.Equals("Text")) {
                    newData.SetData(format, Regex.Replace(((String)oldData.GetData(format)), "\r\n$", ""));
                } else {
                    newData.SetData(format, oldData.GetData(format));
                }
            }
            Clipboard.SetDataObject(newData);
        }
