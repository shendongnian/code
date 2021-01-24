c#
public async Task<IActionResult> GetTodo(long id) =>
    ToActionResult(await _context.Todos.FindAsync(id)) ?? NotFound();
private static IActionResult ToActionResult<T>(T x) 
    where T : class =>
        x == null
            ? null
            : ((IConvertToActionResult) new ActionResult<T>(x)).Convert();
