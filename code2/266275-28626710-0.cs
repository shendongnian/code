                NumberIn1S = o.NumberIn1S,
                Total = o.Total,
                SaleDate = o.SaleDate,
                Comments = o.Comments,
                Driver = o.Driver,
                GuidIn1S = o.GuidIn1S
            }).OrderByDescending(o => o.SaleDate).ToList(); </p>
