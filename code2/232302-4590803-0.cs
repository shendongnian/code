    var rates = ctx.Rates
                   .Where( r => r.Id == Id )
                   .GroupBy( g => g.UserId, r => r.Rating )
                   .Select( g => new
                    {
                       UserId = g.Key,
                       Rating = g.Average()
                    }); 
