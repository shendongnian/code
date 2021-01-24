    var result = new FileHelperEngine<Test>()
        .ReadString(@"123,That's the string, 456")
        .Single();
    Console.WriteLine(result);
                
    var context = new ValidationContext(result, serviceProvider: null, items: null);
    var results = new List<ValidationResult>();
    var isValid = Validator.TryValidateObject(result, context, results, validateAllProperties: true);
    if (!isValid)
    {
        Console.WriteLine("Not valid");
        foreach (var validationResult in results)
        {
            Console.WriteLine(validationResult.ErrorMessage);
        }
    } 
