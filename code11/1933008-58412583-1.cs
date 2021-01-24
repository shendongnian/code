c#
public async Task<IActionResult> GetTodo(long id)
{
    var todo = await _context.Todos.FindAsync(id);
    return todo != null
        ? (IActionResult)(new JsonResult(todo)) 
        : NotFound();
}
