services.AddTransient<TextNullValidation>();
services.AddTransient<TextLetterValidation>();
services.AddTransient<Func<string, IValidation>>(sp => key =>
{
    switch (key)
    {
        case "TextNullValidation":
            return sp.GetService<TextNullValidation>();
        case "TextLetterValidation":
            return sp.GetService<TextLetterValidation>();
        default:
            throw new KeyNotFoundException();
    }
});
and use factory where you inject interface
private readonly IValidation _validation;
public Test(Func<string, IValidation> validationFactory)
{
    // will provide TextNullValidation instance
    _validation = validationFactory("TextNullValidation"); 
}
or register both:
services.AddTransient<IValidation, TextNullValidation>();
services.AddTransient<IValidation, TextLetterValidation>();
and change code so you have access to each implementation
private readonly ICollection<IValidation> _validation;
public xyz(ICollection<IValidation> validation)
{
    _validation = validation;
}
