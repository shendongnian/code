    foreach (var item1 in table1.Where(i => i.Code == InputCode))
    {
        foreach (var code in object)
        {
            // This could be SingleOrDefault, I don't know if you have duplicates in the list or not
            var item2 = item1.List.LastOrDefault(i => i.Code == code);
            
            if(item2 != null)
            {
                final.Add(new tempData
                {
                    Code = item2.Code,
                    Description = item2.Description,
                });
            }
        }
    }
