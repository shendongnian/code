    var results = new List<ValidationResult>();
    Person dude = new Person();
    System.ComponentModel.TypeDescriptor.AddProviderTransparent
    (new AssociatedMetadataTypeTypeDescriptionProvider(dude.GetType()), dude.GetType());
    dude.PhoneNumber = "555-867-5309";
    var vc = new ValidationContext(dude, null, null);
    vc.MemberName = "PhoneNumber";   
    bool result = Validator.TryValidateProperty(dude.PhoneNumber, vc, results);
