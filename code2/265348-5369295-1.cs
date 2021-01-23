public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
{
	if( NumberField < 0 )
	{
		yield return new ValidationResult( 
				"Don't input a negative number", 
				new[] { "NumberField" } );
	}
	if( NumberField > 100 )
	{
		yield return new ValidationResult( 
				"Don't input a number > 100", 
				new[] { "NumberField" } );
	}
	yield break;
}
