    var buildings = _context.Buildings
                         .Select(x => new 
                                  { 
                                     Building = x,
                                     Apartments = _context.Apartments
                                               .Where(apartment=>
                                                apartment.State == ApartmentState.Approved 
                                                && apartment.Accessibility == AccessibilityState.Saleable)
                                   });
