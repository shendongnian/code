<ListView  HasUnevenRows="True" ItemsSource="{Binding MyItems}" SelectedItem="{Binding SelectItems,Mode=TwoWay}">
<Grid.Style>
   <Style TargetType="Grid">
      <Setter Property="HeightRequest" Value="60"/>
      <Style.Triggers>
        <DataTrigger TargetType="Grid" Binding="{Binding IsCheck}" Value="True">
            <DataTrigger.EnterActions>
                <local:ForceUpdateSizeTriggerAction HeighRequest="120" />
            </DataTrigger.EnterActions>
            <DataTrigger.ExitActions>
                <local:ForceUpdateSizeTriggerAction HeighRequest="60" />
            </DataTrigger.ExitActions>
        </DataTrigger>
      </Style.Triggers>
   </Style>
</Grid.Style>
###in Code Behind
**ViewMode**
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Model> MyItems { get; set; }
        private Model selectItems;
        public Model SelectItems
        {
            get
            {
                return selectItems;
            }
            set
            {
                if (selectItems != value)
                {
                    selectItems = value;
                    NotifyPropertyChanged();
                    foreach(Model model in MyItems)
                    {
                        if(selectItems==model)
                        {
                            model.IsCheck = !model.IsCheck;                         
                        }
                    }
                }
            }
        }
        
        public MyViewModel()
        {
            SelectItems = null;
            MyItems = new ObservableCollection<Model>() {
                new Model(){ IsCheck=false},
                new Model(){ IsCheck=false},
                new Model(){ IsCheck=false},
                new Model(){ IsCheck=false},
                new Model(){ IsCheck=false},
                new Model(){ IsCheck=false},
                new Model(){ IsCheck=false},
            };
     }
**Model**
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool isCheck;
        public bool IsCheck
        {
            get
            {
                return isCheck;
            }
            set
            {
                if (isCheck != value)
                {
                    isCheck = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private double height;
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (height != value)
                {
                    height = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
