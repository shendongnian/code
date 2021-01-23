    public class CheckBoxItemForWPF : IComparable<CheckBoxItemForWPF>, INotifyPropertyChanged
    {
        public object Item { get; set; }
        private string _label;
        public string Label
        {
            get { return _label; }
            set { _label = value; OnPropertyChanged("Label"); }
        }
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; OnPropertyChanged("IsChecked"); }
        }
        private SolidColorBrush _couleur;
        public SolidColorBrush Couleur
        {
            get { return _couleur; }
            set { _couleur = value; OnPropertyChanged("Couleur"); }
        }
        public CheckBoxItemForWPF(object item)
        {
            this.Item = item;
            this.Label = item.ToString();
            this.IsChecked = true;
            this.Couleur = new SolidColorBrush(Colors.White);
        }
        public CheckBoxItemForWPF(object item, string label)
        {
            this.Item = item;
            this.Label = label;
            this.IsChecked = true;
            this.Couleur = new SolidColorBrush(Colors.White);
        }
        public CheckBoxItemForWPF(string label, bool IsChecked)
        {
            this.Label = label;
            this.IsChecked = IsChecked;
            this.Couleur = new SolidColorBrush(Colors.White);
        }
        public CheckBoxItemForWPF(object item, string label, bool IsChecked)
        {
            this.Item = item;
            this.Label = label;
            this.IsChecked = IsChecked;
            this.Couleur = new SolidColorBrush(Colors.White);
        }
        public CheckBoxItemForWPF(object item, string label, bool IsChecked, SolidColorBrush Couleur)
        {
            this.Item = item;
            this.Label = label;
            this.IsChecked = IsChecked;
            this.Couleur = Couleur;
        }
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
            // If parameter cannot be cast to Point return false.
            CheckBoxItemForWPF p = obj as CheckBoxItemForWPF;
            if ((System.Object)p == null)
            {
                return false;
            }
            return Item.Equals(p.Item);
        }
        public override int GetHashCode()
        {
            return Item.GetHashCode();
        }
        public override string ToString()
        {
            return Label;
        }
        public int CompareTo(CheckBoxItemForWPF other)
        {
            return this.Label.CompareTo(other.Label);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
