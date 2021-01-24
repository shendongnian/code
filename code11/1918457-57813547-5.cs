    var ans = src.Scan(new {
                            EmpNumber = 0,
                            EmpName = "",
                            NumberOfDays = 0,
                            Days1 = (GeneratorInt)null,
                            Days2 = (GeneratorInt)null,
                            Days3 = (GeneratorInt)null,
                            Days4 = (GeneratorInt)null,
                            Days5 = (GeneratorInt)null
                       },
                       (acc, r) => new {
                            r.EmpNumber,
                            r.EmpName,
                            r.NumberOfDays,
                            Days1 = r.NumberOfDays >= 1 ? (acc.Days1 ?? new GeneratorInt()) : null,
                            Days2 = r.NumberOfDays >= 2 ? (acc.Days2 ?? new GeneratorInt()) : null,
                            Days3 = r.NumberOfDays >= 3 ? (acc.Days3 ?? new GeneratorInt()) : null,
                            Days4 = r.NumberOfDays >= 4 ? (acc.Days4 ?? new GeneratorInt()) : null,
                            Days5 = r.NumberOfDays >= 5 ? (acc.Days5 ?? new GeneratorInt()) : null,
                       }
                 )
                 .Select(a => new {
                    a.EmpNumber,
                    a.EmpName,
                    a.NumberOfDays,
                    Days1 = a.Days1?.Value,
                    Days2 = a.Days2?.Value,
                    Days3 = a.Days3?.Value,
                    Days4 = a.Days4?.Value,
                    Days5 = a.Days5?.Value,
                 })
                 .ToList();
