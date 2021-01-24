<CheckBox IsChecked="{Binding IsCheck , Mode=TwoWay}"  /> 
###in model
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int Id { get; set; }
        public string Title { get; set; }
        private bool ischeck;
        public bool IsCheck
        {
            get
            {
                return ischeck;
            }
            set
            {
                if (ischeck != value)
                {
                    ischeck = value;
                    NotifyPropertyChanged();
                    MessagingCenter.Send<Object>(this,"CheckChanged");
                }
            }
        }
    }
###in the constructor your contentPage or ViewModel
MessagingCenter.Subscribe<Object>(this, "CheckChanged", (arg) =>
{
   // handle the logic here
   
   var newSources = MyItems.OrderBy(x => x.IsCheck);
   listView.ItemsSource = newSources;
});
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/Q5TmY.gif
