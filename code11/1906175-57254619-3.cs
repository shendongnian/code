    foreach(var building in buildings){
        var saleableApartments = building.Apartments
            .Where(a => a.State == ApartmentState.Approved
                        && a.Accessibility == AccessibilityState.Saleable));
        // Do whatever.
    }
    
