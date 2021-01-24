    var buildings = _context.Buildings
                      .Select(building => new 
                              { 
                                 Building = building ,
                                 Apartments = _context.Apartments
                                           .Where(apartment=>
                                            building.Id == apartment.BuildingId &&
                                            apartment.State == ApartmentState.Approved &&
                                            apartment.Accessibility == AccessibilityState.Saleable)
                               });
