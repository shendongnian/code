c#
public async Task<IActionResult> GetTodo(long id)
{
    var todo = await _context.Todos.FindAsync(id);
    return 
        ((IConvertToActionResult)(ActionResult<Todo>)todo).Convert() ?? 
        NotFound();
}
