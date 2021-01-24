    public async Task<ActionResult<Todo>> GetTodo(long id)
    {
        Todo todo = await _context.Todos.FindAsync(id);
        if (todo != null)
        {
            return todo;
        }
        else
        {
            return NotFound();
        }
    }
