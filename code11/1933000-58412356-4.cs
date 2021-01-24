    public async Task<IActionResult<Todo>> GetTodo(long id)
    {
        return OkOrNull(await _context.Todos.FindAsync(id)) ?? NotFound();
    }
    
