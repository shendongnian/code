    int ratingId = 1; 
	int personId = 9;
    var ratingAverage = ctx.Rates.Where(
		 r => r.Id == ratingId && r.Person.Id == personId)  
       .GroupBy(g => g.Id, r => r.Rating)  
       .Select(g => new { Id = g.Key, Rating = g.Average() });
