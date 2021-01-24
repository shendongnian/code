    public ActionResult AddToCart(IFormCollection collection)
    {
        ...
        var produtoContext = _context.Produto
            .Include(c => c.IdCategoriaNavigation)
             ^^^^
            .Include(c => c.IdTamanhoNavigation)
             ^^^^
            .Include(c => c.IdTipoMassaNavigation)
             ^^^^
           .FirstOrDefault(p => p.Nome == Nome && p.IdTamanho == IdTamanho 
        && p.IdTipoMassa == IdTipoMassa);
        ... 
        The produtoContex here, normally has all the values from the related tables.
            {PianoPizza.Models.Categoria} 
            {PianoPizza.Models.Tamanho}
            {PianoPizza.Models.TipoMassa}
            But when I set the List on Session I got the Json error.     
        HttpContext.Session.Set("itens", itens);
                            ^^^^
        ...
     }
