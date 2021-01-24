    var drFrilaKeys = new string[] { "EMISOR", "RECEPTOR" };
    var searchTerms = new string[] { "CRUDO", "MEZCLA" };
    var allDrFilaMovimientosContainASearchTerm = drFrilaKeys.All(key => searchTerms.Any(searchTerm =>
        drFilaMovimientos[key].ToString().Contains(searchTerm)
    ));
    
    if (allDrFilaMovimientosContainASearchTerm) {
     // Code here
    }
