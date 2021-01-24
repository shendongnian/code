    private double _equalSize;
        public double EqualSize {
            get { return _equalSize; }
            set {
                if (_equalSize!=value) {
                    _equalSize = value;
                    RaisePropertyChanged();
                }
            }
        }
        private void ListView1_SizeChanged(object sender, SizeChangedEventArgs e) {
            EqualSize = (colDef.ActualWidth - 200) / 4;
        }// The magic number 200 is the size of the first column and 4 is the number of columns that share the same size
