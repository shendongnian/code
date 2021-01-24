var query = from c in collection1.AsQueryable().Where(x => x.Name == "Test")
			join m in collection2.AsQueryable() on
			c.ClassTwoId equals m.Id into j
			select new { c, j };
Making it dynamic by adding nuget package System.Linq.Dynamic 
using System.Linq.Dynamic;
....
var query = from c in collection1.AsQueryable().Where("Age == 123")
			join m in collection2.AsQueryable() on 
			c.ClassTwoId  equals m.Id into j
			select new { c, j };
For more information on the Dynamic queries see documentation on System.Linq.Dynamic (parameters etc.)
