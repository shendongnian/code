    public MainPage()
    {
        InitializeComponent();
        //-------Get TodoItem here-------------
        ClassOne classOne = new ClassOne();
        GetTasksAsync(classOne);
    }
    // from this method in other class
    public Task<TodoItem> GetTasksAsync(ClassOne classOne)
    {
         return classOne.PassTodoValue();
    }
