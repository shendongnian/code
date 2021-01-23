    // MyButton.xaml.cs
    public partial class MyButton : Button
    {
        public MyButton()
        {
            InitializeComponent();
            this.DataContextChanged += DataContext_Changed;
        }
    
        private void DataContext_Changed(Object sender,DependencyPropertyChangedEventArgs e)
        {
           INotifyPropertyChanged notify = e.NewValue as INotifyPropertyChanged;
           if(null != notify)
           {
              notify.PropertyChanged += DataContext_PropertyChanged;
           }
        }
    
        private void DataContext_PropertyChanged(Object sender,PropertyChangedEventArgs e)   
        {
            if(e.PropertyName == "MySubProperty")
               MySubPropertyChanged((sender as YourClass).MySubProperty);
        } 
    
        public void MySubPropertyChanged(string newValue)
        {
            // ...
        }
    }
