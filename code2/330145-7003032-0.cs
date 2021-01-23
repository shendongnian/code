    var histogram = myListOfLines
        //Split each string along spaces or tabs, and discard any zero-length strings
        //caused by multiple adjacent delimiters.
       .Select(s=>s.Split(new[]{'\t',' '}, StringSplitOptions.RemoveEmptyEntries))
        //Optional; turn the array of strings produced by Split() into an anonymous type
       .Select(a=>new{Col1=a[0], Col2=a[1], Col3=a[2], Col4=a[3], Col5=a[4]})
        //Group based on the values of the second column.
       .GroupBy(x=>x.Col2)
        //Then, out of the grouped collection, get the count for each unique value of Col2.
       .Select(gx=>new{gx.Key, gx.Count()});
