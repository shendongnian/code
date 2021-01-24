    public class PersonValidator : AbstractValidator<Person>
    {
    	private readonly HttpClient HttpClient;
    
    	public PersonValidator(HttpClient httpClient)
    	{
    		HttpClient = httpClient;
    		RuleFor(x => x.EmailAddress)
    			.MustAsync(BeAvailable)
    			.WithMessage("Email address is not available");
    	}
    
    	private Task<bool> BeAvailable(
    		Person person,
    		string emailAddress,
    		PropertyValidatorContext context,
    		CancellationToken cancellationToken)
    	{
    		return HttpClient.PostJsonAsync<bool>("/Person/IsEmailAddressAvailable", new { EmailAddress = emailAddress });
    	}
    }
