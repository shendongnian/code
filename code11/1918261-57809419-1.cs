(from sd in Stockdiaries
join loc in Locations on sd.Location equals loc.Id
join prod in Products on sd.Product equals prod.Id
join cat in Categories on prod.Category equals cat.Id into pCat
from cat in pCat.DefaultIfEmpty()
select new {
    Location = loc.Name,
    Category = cat.Name,
    Reference = prod.Reference,
    Product = prod.Name,
    sd.Units,
    sd.Price
    } into cnd
group cnd by new {cnd.Location,cnd.Reference, cnd.Product, cnd.Category} into g
orderby g.Key.Location, g.Key.Category, g.Key.Product
select new {
        g.Key.Location,
        g.Key.Reference,
        g.Key.Product,
        g.Key.Category,
        UnitsOut = g.Sum(row => row.Units < 0 ? row.Units : 0),
        TotalOut = g.Sum(row => row.Units < 0 ? row.Units * row.Price : 0),
        UnitsIn = g.Sum(row => row.Units >= 0 ? row.Units : 0),
        TotalIn = g.Sum(row => row.Units >= 0 ? row.Units * row.Price : 0),
        UnitsDiff = g.Sum(row => row.Units),
        TotalDiff = g.Sum(row => row.Units * row.Price)
    
})
