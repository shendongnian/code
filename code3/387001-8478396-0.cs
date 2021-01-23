      public class BinaryTreeData : INotifyPropertyChanged
      {
        private int _ownID;
        private int _parentID;
    
        public int ownID
        {
          get { return this._ownID; }
          set
          {
            this._ownID = value;
            this.onChange("ownID");
          }
        }
    
        private List<BinaryTreeData> _subitems = new List<BinaryTreeData>();
    
        public List<BinaryTreeData> Subitems
        {
          get { return _subitems; }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void onChange(string propertyName)
        {
          if (PropertyChanged != null)
          {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
        }
      }
