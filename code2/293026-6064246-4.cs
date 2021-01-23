    public class CheckBoxValueCollection : ObservableCollection<CheckBoxValue>
    {
        public CheckBoxValueCollection(IEnumerable<string> values)
        {
            foreach (var value in values)
            {
                var checkBoxValue = new CheckBoxValue { Description = value };
                checkBoxValue.PropertyChanged += (s, e) => OnPropertyChanged(new PropertyChangedEventArgs("SelectedItem"));
                this.Add(checkBoxValue);
            }
            this[0].IsChecked = true;
        }
        public string SelectedItem
        {
            get { return this.First(item => item.IsChecked).Description; }
        }
    }
