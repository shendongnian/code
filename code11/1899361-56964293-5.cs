    public MainPage()
    {
        InitializeComponent();
        //-------Get TodoItem here-------------
        ClassOne classOne = new ClassOne();
        Console.WriteLine("----"+ GetTasksAsync(classOne).Result.followerCount);
        Console.WriteLine("----"+ GetTasksAsync(classOne).Result.followingCount); 
        Console.WriteLine("----"+ GetTasksAsync(classOne).Result.postCount);  
    }
    // from this method in other class
    public Task<TodoItem> GetTasksAsync(ClassOne classOne)
    {
         return classOne.PassTodoValue();
    }
