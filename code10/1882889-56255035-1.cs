        private string _convertedSerialData;
        public string ConvertedSerialData
        {
            get => _convertedSerialData;
            set
            {
                _convertedSerialData = value;
                MainWindow._MainWindow.SerialData= value == null ? "" : value;
            }
        }
