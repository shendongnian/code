    var existingPeopleList = _context.People.AsNoTracking()
                                     .Where(e => e.companyId == request.companyId) 
                                     .ToListAsync();
    var requestEntities = request.Select(r => new PersonEntity(r)).ToList();
    var requestedPeopleList = requestEntities.Select(re => new People()
                              {
                                  Id = re.Id,
                                  CompanyId = 9,
                                  Name = re.Name
                              }).ToList();
    
    var peopleToBeRemoved = existingPeopleList.Where(ep => requestedPeopleList.All(rp => rp.Id != ep.Id)).ToList();
    
    var peopleToBeAdded = requestedPeopleList.Where(rp => existingPeopleList.All(ep => ep.Id != rp.Id)).ToList();
  
    var peopleToBeUpdated = requestedPeopleList.Where(rp => existingPeopleList.Any(ep => ep.Id == rp.Id)).ToList();
    _context.People.RemoveRange(peopleToBeRemoved);
    _context.People.AddRange(peopleToBeAdded);
    _context.People.UpdateRange(peopleToBeUpdated);
    await _context.SaveChangesAsync();
