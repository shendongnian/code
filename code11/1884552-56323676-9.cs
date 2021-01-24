    public class TodoViewModel
	{
		public ObservableCollection<Todo> TodoList { get; } = new ObservableCollection<Todo>();
		public TodoViewModel()
		{
			TodoList.Add(new Todo { TaskName = "Todo1", Description = "Todo 1 Description", Priority = 1 });
			TodoList.Add(new Todo { TaskName = "Todo2", Description = "Todo 2 Description", Priority = 2 });
		}
	}
