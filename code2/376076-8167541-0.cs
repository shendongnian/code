     string MyCountry = "Austria";
     string MyProductId = 11
     
     var Predicate = PredicateBuilder.True<db.Customers>();
     Predicate = Predicate.And(p=>p.Country ==MyCountry && p.Order.SelectMany(o=>o.Item).Where(i=>i.id == 11).Count() >0);
     
     var list = Customers.Where(Predicate).Select(s=>s).ToList();
