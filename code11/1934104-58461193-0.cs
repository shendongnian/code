cs
public async Task SaveAsync(Cliente cliente) 
{
    ... code ommited for brevity
    else 
    {
        var savedCliente = _cadastroContext.Include(c => c.Conta).FirstOrDefault(c = c.Id == cliente.Id);
        savedCliente = cliente;
        _cadastroContext.Update(savedCliente);
        await _cadastroContext.SaveChangesAsync()
    }
