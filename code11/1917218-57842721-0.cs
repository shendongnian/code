    public class MyModelValidator : AbstractValidator<MyModel>
    {
    	public MyModelValidator()
    	{
    		When(x => x.MyPropertyA != null, rules: new[]
    		{
    			RuleFor(x => x.MyPropertyB).NotEmpty(),
    			RuleFor(x => x.MyPropertyC).NotEmpty()
    		});
    	}
    
    	private void When<T>(Func<MyModel, bool> predicate, IEnumerable<IRuleBuilderOptions<MyModel, T>> rules)
    	{
    		foreach (var rule in rules)
    		{
    			rule.When(predicate);
    		}
    	}
    }
