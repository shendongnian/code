    var query  = await _context.Experiences.AsQueryable();
        
                        if(filterExperience.MinPrice.HasValue)
                            query = query.Where(x.Price >= filterExperience.MinPrice)
        
                        if (filterExperience.MaxPrice.HasValue)
                            query = query.Where(x.Price >= filterExperience.MaxPrice);
        
                        if(filterExperience.Rating.HasValue)
                            query = query.Where(x.Rating == filterExperience.Rating);
        
                        .
                        ..
                        ....
        
        
        
                        var expriences = query.ProjectTo<ExperienceListDto>().ToListAsync();
