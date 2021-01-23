    // In PersonPartial.cs
    public partial class Person
    {
        public string DisplayText
        {
            get { return string.Format("{0} {1}", Name, Vorname); }
        }
        partial void OnNameChanged()
        {
            OnPropertyChanged("DisplayText");
        }
        partial void OnVornameChanged()
        {
            OnPropertyChanged("DisplayText");
        }
    }
    <!-- in xaml -->
    <ComboBox ... DisplayMemberPath="DisplayText" />    
