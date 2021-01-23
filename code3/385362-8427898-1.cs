     rows = query.Select(x => new
            {
                x.Id,
                cell = new string[]
                {
                    x.Id.ToString(),
                    x.Name.ToString(),
                    x.PartNr.ToString(),
                    x.Category.Name.ToString()
                }
            }).ToArray()
