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
                 
                }
            }
        }
    }
###in the constructor your contentPage or ViewModel
foreach(var product in MyItems) // MyItems here is ItemsSource of your listview
{
   product.PropertyChanged += Product_PropertyChanged;
}
//...
private void Product_PropertyChanged(object sender, PropertyChangedEventArgs e)
{
  if(e.PropertyName== "IsCheck")
  {
     var newSources = MyItems.OrderBy(x => x.IsCheck);
     listView.ItemsSource = newSources;
  }
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/Q5TmY.gif
