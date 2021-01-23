    public void SaveTodo ( TodoWrapper note )
    {
    	using (Repository repo = new Repository(new HpstrDataContext()))
    	{
    		if (note != null)
    		{
    			Todo todo = repo.Todos.SingleOrDefault(t => t.todoId == note.todoId);
    			if (todo == null)
    			{
    				todo = new Todo();
    				todo.Note = new Note();
    			}
    			todo.dueDate = note.dueDate;
    			todo.priority = (short)note.priority;
    			todo.Note.isTrashed = note.Note.isTrashed;
    			todo.Note.permission = (short)note.Note.permission;
    			todo.Note.noteTitle = note.Note.noteTitle;
    			foreach (TaskWrapper item in note.Tasks)
    			{
    				Task t = repo.Tasks.SingleOrDefault(task => task.tasksId == item.taskId);
    				if (t == null)
    				{
    					t = new Task();
    				}
    				t.Todo = todo;
    				t.isCompleted = item.isCompleted;
    				t.content = item.content;
    				repo.SaveTask(t);
    			}
    		}
    	}
    }
