    var inputItems =
            input.Split('|')
                .Select(
                    x =>
                    x.Split(';')
                     .ToDictionary(
                        y => y.Split('=')[0],
                        y => y.Split('=')[1]
                     )
                )
                .Select(
                    x => //Manual parsing from dictionary to inputClass. 
                    //If dictionary Key match an object property we could use something more generik.
                    new inputClass
                    {
                        I = decimal.Parse(x["I"], CultureInfo.InvariantCulture.NumberFormat),
                        A = decimal.Parse(x["A"], CultureInfo.InvariantCulture.NumberFormat),
                        D = decimal.Parse(x["D"], CultureInfo.InvariantCulture.NumberFormat),
                    }
                )
                .ToList();
