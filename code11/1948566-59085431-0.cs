     var query = (from c in repos.GetTable<Table1>()
                            join ct in repos.GetTable<Table2>()
                            on c.Nr_PY equals ct.Nr_PY1 into g
                            from ct in g.DefaultIfEmpty()
                            select new myclass
                            {
                                value1=ct.Nr_PY1,
                                value2=c.Name,
                            }).ToList();
