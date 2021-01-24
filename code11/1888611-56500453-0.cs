    var ProdsProdDef = from p in context.Products
                       join pd in context.ProductDefendant on p.Id equals pd.ProductId
                       select new { p, pd };
    if (input.DefendantId != null) {
        ProdsProdDef = from ppd in ProdsProdDef
                       where ppd.pd.DefendantId == input.DefendantId
                       select ppd;
    }
    var ProdsProdDefDef = from ppd in ProdsProdDef
                          join d in context.Defendants on ppd.pd.DefendantId equals d.Id
                          select new { ppd.p, ppd.pd, d };
    if (input.DefendantCode != null && input.DefendantId == null) {
        ProdsProdDefDef = from ppdd in ProdsProdDefDef
                          where ppdd.d.DefendantCode.Any(rp => EF.Functions.Like(ppdd.d.DefendantCode, "%" + input.DefendantCode + "%"))
                          select ppdd;
    }
    if (input.ProductId != null) {
        ProdsProdDefDef = ProdsProdDefDef.Where(ppdd => ppdd.p.Id == input.ProductId);
    }
    if (input.ProductName != null && input.ProductId == null) {
        ProdsProdDefDef = ProdsProdDefDef.Where(ppdd => EF.Functions.Like(ppdd.p.ProductName, "%" + input.ProductName + "%"));
    }
    var productsVM = from ppdd in ProdsProdDefDef
                     select new GetProductsReturnViewModel {
                         Id = ppdd.p.Id,
                         ProductName = ppdd.p.ProductName,
                         DefendantCode = ppdd.d.DefendantCode
                     };
