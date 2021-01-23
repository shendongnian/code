    class ParentClass
    {
          [Required]
          public Address MailingAddress { get; set; }
          public Address BillingAddress { get; set; }
    }
    (...)
    Type t = typeof(ParentClass);
    foreach (PropertyInfo p in t.GetProperties())
    {
        Attribute a = Attribute.GetCustomAttribute(p, typeof(RequiredAttribute));
        if (a != null)
        {
              // The property is required, apply your logic
        }
        else
        {
              // The property is not required, apply your logic
        }
    }
