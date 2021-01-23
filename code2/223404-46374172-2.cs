    public MyView(Window win) //ctor of your view, window as parameter
        {
            InitializeComponent();
            MyButton.CommandParameter = win;
            MyButton.Command = ((MyViewModel)this.DataContext).CloseWindowCommand;
        }
