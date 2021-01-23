    // Cast to IEnumerable<MyBaseClass> isn't helping you, so why bother?
    object cln = pi.GetValue(this, null);
    // Create car.
    object car = ...
    // Invoke Add method on 'cln', passing 'car' as the only argument.
    pi.PropertyType.GetMethod("Add").Invoke(cln, new[] { car } );
