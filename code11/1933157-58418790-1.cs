     var details = dt.AsEnumerable().GroupBy(x =>
                new
                {
                    ID= x.Field<decimal>("ID"),
                    NAME = x.Field<string>("NAME"),
                    TYPE = x.Field<string>("TYPE"),
                    TERMS = x.Field<string>("TERMS")
                })
            .Select(x =>
                new Details
                {
                    x.Key.ID,
                    x.Key.NAME,
                    x.Key.TYPE,
                    x.Key.TERMS,
                    Faqs =
                    x.Select(
                        s => new Faq {Question = s.Field<string>("QUESTION"), Answer = s.Field<string>("ANSWER")}).ToList()
                }).ToList();
