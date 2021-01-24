    var invalidItems = ModelState.Where(ms => ms.Value.Errors.Any());
    foreach (ModelState item in invalidItems)
    {
        // Here you have access to item.Key which is name of the property
        // And value which is current model state for property 
    }
