c#
public async Task<IActionResult> GetTodo(long id)
{
    return (IActionResult)(await _context.Todos.FindAsync(id)) ?? NotFound();
}
