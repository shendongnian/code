    var customer = new Customer();
    TypeDescriptor.AddProviderTransparent
    (new AssociatedMetadataTypeTypeDescriptionProvider
        (customer.GetType()), customer.GetType());
    customer.SSN = "";
    var vc = new ValidationContext(customer, null, null);
    vc.MemberName = "SSN";
    var res = new List<ValidationResult>();
    var result = Validator.TryValidateProperty(customer.SSN, vc, res);
