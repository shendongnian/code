    public async Task<ActionResult<Todo>> GetTodo(long id)
    {
        Todo todo = await _context.Todos.FindAsync(id);
        return todo ?? NotFound();
    }
