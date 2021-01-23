            var baseQuery = dataAccess.Table1.Where(arg => arg.Field1 = 1);
            if (parameter[1] = true)
            {
                baseQuery = baseQuery.Where(arg => arg.Field2 = 'Test');
            }
            if (parameter[2] = true)
            {
                baseQuery = 
                    from x in baseQuery
                    join y in dataAccess.Table2 on
                        x.Id equals y.Id
                    where y.Field3 = 'Something'
                    select x;
            }
            return baseQuery.ToList();
