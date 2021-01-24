    public class TodoItemViewModel
    {
        public long id { get; set; }
        public string title { get; set; }
        public bool IsComplete { get; set; }
    }
    public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItemViewModel model)
    {
        var item = new TodoItem(item.id, item.title); 
        ...
    }
