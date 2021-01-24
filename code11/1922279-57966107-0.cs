        private Model _myModel;
        public Model MyModel
        {
            get
            {
                return _myModel;
            }
            set
            {
                _myModel = value;
                OnPropertieChanged();
            }
        }
        public ICommand Command1 { get; set; }
        public MainVM()
        {
            MyModel = new Model();           
            Command1 = new Command((obj) => MyModel.ChangeValue());
        }
And bind to it's ModelValue property in the xaml.
    <StackPanel>
        <TextBlock Text="{Binding MyModel.ModelValue}"/>
        <Button Height="50" Width="100" Command="{Binding Command1}"/>
    </StackPanel>
In general, though, a model class doesn't typically perform logic; rather, logic is either performed on instances of your model in a service class, or client-side in the view model. But that's a separate discussion.
