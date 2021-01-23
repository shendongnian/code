            var baseQuery = dataAccess.Table1.Where(arg => arg.Field1 = 1);
            if (parameter[1] = true)
            {
                baseQuery = baseQuery.Where(arg => arg.Field2 = 'Test');
            }
            return baseQuery.ToList();
