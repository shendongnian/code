    var _context = _scope.ServiceProvider.GetRequiredService<VMContext>();
    var listCEQuery = _context.Ce.Where(x => x.VuId == element.VuId)
            
    if (boolparameter == true)
        listCEQuery = listCEQuery.Where(x => x.Score == 8)
    var listCE = listCEQuery.AsNoTracking().ToList();
