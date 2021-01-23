    public class DPGroup : DependencyObject, INotifyPropertyChanged 
    {      
        public static readonly DependencyProperty MyProperty1Property =
            DependencyProperty.RegisterAttached(
            "MyProperty1",
            typeof(int),
            typeof(DPGroup),
            new PropertyMetadata(1));
        public int MyProperty1
        {        
            get { return (int)GetValue(MyProperty1Property); }        
            set { SetValue(MyProperty1Property, value); }
        } 
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
 	        base.OnPropertyChanged(e);
            NotifyPropertyChanged(e.Property.Name);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class DPTest : UserControl   
    {     
        public static readonly DependencyProperty GroupProperty =         
            DependencyProperty.Register(
            "Group",
            typeof(DPGroup),
            typeof(DPTest),
            new PropertyMetadata(
                new DPGroup(),
                new PropertyChangedCallback(OnGroupPropertyChanged)
                )
            );
        
        public DPGroup Group     
        {
            get { return (DPGroup)GetValue(GroupProperty); }
            set { SetValue(GroupProperty, value);}     
        }
        
        static void OnGroupPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DPTest control = (DPTest)d;
            DPGroup oldGroup = e.OldValue as DPGroup;
            if (oldGroup != null)
            {
                oldGroup.PropertyChanged -=new PropertyChangedEventHandler(control.group_PropertyChanged);
            }
            DPGroup newGroup = e.NewValue as DPGroup;
            if (newGroup != null)
            {
                newGroup.PropertyChanged +=new PropertyChangedEventHandler(control.group_PropertyChanged);
            }
            control.UpdateTextBox();
        }
        private void group_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.UpdateTextBox();
        }
        private void UpdateTextBox()
        {
 	        this.textBox1.Text = this.Group.MyProperty1.ToString(); 
        }
        private TextBox textBox1;
    }  
