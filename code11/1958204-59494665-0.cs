    if (!string.IsNullOrEmpty(sOrdenar))
    {
        IEnumerable<Clientes_view> list = await clientes.AsAsyncEnumerable();
        list = list.Where(.....); //here you may use everything you like
        return list;
    }
