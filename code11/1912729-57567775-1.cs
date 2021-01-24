    public class Tool
    {
        private ObservableCollection<ComboElement> comboFaceSlot = new ObservableCollection<ComboElement> { new ComboElement { MyInt = 0, MyString = "Web" }, new ComboElement { MyInt = 1, MyString = "Top" }, new ComboElement { MyInt = 2, MyString = "Bottom" }, new ComboElement { MyInt = 3, MyString = "Back" } };
        public ObservableCollection<ComboElement> ComboFaceSlot
        {
            get { return comboFaceSlot; }
            set
            {
                this.comboFaceSlot = value;
                this.NotifyPropertyChanged("ComboFaceSlot");
            }
        }
        private long face = 0;
        public long Face
        {
            get { return face; }
            set
            {
               this.face = value;
               this.NotifyPropertyChanged("Face");
            }
        }
    }
