    public class GameViewModel : ViewModelBase
    {
        public void Load()
        {
            var array = new CellModel[9, 9];
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    CellArray[i, j] = new CellModel()
                    {
                        //TODO: init properties of the cell[i, j]
                    };
                }
            }
            this.CellArray = array;
        }
        CellModel[,] _CellArray;
        public CellModel[,] CellArray
        {
            get
            {
                return _CellArray;
            }
            private set
            {
                if (_CellArray == value) return;
                _CellArray = value;
                NotifyPropertyChanged("CellArray");
            }
        }
    }
