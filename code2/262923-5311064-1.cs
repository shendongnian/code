            TestEntities ctx = new TestEntities();
            var data = from d in ctx.MyTables select new { d.Id, d.Data1 };
            var data2 = data.AsEnumerable().Select(x => new MyTable(){Id = x.Id, Data1 =  x.Data1 });
            var data3 = data2.ToList();
            foreach (var item in data3)
            {
                ctx.MyTables.Attach(item);
            }
            data3[0].Data1 = "Hello";            
            ctx.SaveChanges();
