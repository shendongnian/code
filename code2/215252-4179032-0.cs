    public partial class EditableListBox : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // You really should make this protected. You do not want the outside world
        // to be able to fire PropertyChanged events for your class.
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private bool _editing;
        public bool Editing
        {
            get
            {
                return _editing;
            }
            set
            {
                _editing = value;
                NotifyPropertyChanged("Editing");
            }
        }
    }
    public class EditableListItem : INotifyPropertyChanged
    {
        private EditableListBox _parentListBox;
        public EditableListItem(EditableListBox parentListBox)
        {
            _parentListBox = parentListBox;
            _parentListBox.PropertyChanged += new PropertyChangedEventHandler(_parentListBox_PropertyChanged);
        }
        void _parentListBox_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Forward the event.
            if (e.PropertyName == "Editing")
                NotifyPropertyChanged("Editing");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        // You really should make this protected. You do not want the outside world
        // to be able to fire PropertyChanged events for your class.
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public bool Editing
        {
            get
            {
                return _parentListBox.Editing;
            }
        }
    }
