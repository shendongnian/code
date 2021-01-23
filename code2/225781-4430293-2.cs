    var data = from g in db.Projects.Select(p => 
                    new
                    {
                        Name = p.ProjectName,
                        Customer = p.CustomerID,
                        Cost = p.Cost
                    }
                ).GroupBy(p => p.Customer)
                let something = g.Sum(p => p.Cost)
                select new
                {
                    Something = something,
                    SomethingElse = something * 0.25
                };
