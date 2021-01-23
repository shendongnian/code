    IEnumerable<MyClass> result = items
        .OrderBy(item => item.State)
        .ThenBy(item =>
        {
            switch (item.State)
            {
                case 1: return item.Value1;
                case 2: return item.Value2;
            }
            throw new Exception();
        });
