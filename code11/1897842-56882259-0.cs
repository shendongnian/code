    var productsDesc = (from pr in context.Product.Where(m => m.Id == 123)
                                    join prg in context.PrGroup
                                    on pr.GroupId equals prg.Id
                                    join pg in context.PrParamGroup
                                    on pr.PrParamGroupId equals pg.Id into tmp1
                                    from t1 in tmp1.DefaultIfEmpty()
                                    from prm in context.PrParam
                                    join px in context.PrParam2ProductX
                                    on new { a = pr.Id, b = px.ProductId } equals new { a = prm.Id, b = px.PrParamId } into tmp2
                                    from t2 in tmp2.DefaultIfEmpty()
                                    join gx in context.PrParam2GroupX
                                    on new { prm.Id = gx.PrParamId } equals new {  pg.Id = gx.PrParamGroupId } into tmp3
                                    from t3 in tmp3.DefaultIfEmpty()
                                    select new
                                    {
                                        Name = prm.Descr,
                                        Value = t2.Value,
                                        Unit = prm.Unit ?? ""
                                    }).ToList();
