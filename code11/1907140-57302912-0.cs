var list = from a in db.VeiculoComSeminovo
                       group a by a.descricaoFamiliaNovo into g
                       select new ViewBag{
                                  familiasCount=g.Count()
                       };
or
var list = db.VeiculoComSeminovo.GroupBy(a => a.descricaoFamiliaNovo)
                                .Select (g => new ViewBag
                                     {
                                      familiasCount=g.Count()
                                     });
If you need column value:
new ViewBag{
   FieldName=g.Key,
   familiasCount=g.Count()
};
