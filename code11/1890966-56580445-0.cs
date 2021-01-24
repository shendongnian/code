csharp
[HttpGet]
public async Task<ActionResult<IEnumerable<Empresa>>> getEmpresas()
{
    var empresas =  await _context.Empresas.Include(t=> t.Funcionarios).ToListAsync();
    return Ok(Empresas);
}
