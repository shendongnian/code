    @using System.ComponentModel.DataAnnotations
    <tbody>
    	@foreach (SomeModel m in Model)
    	{ 
		    ValidationContext vc = new ValidationContext(m);
	    	ICollection<ValidationResult> results = new List<ValidationResult>(); 
    		bool isValid = Validator.TryValidateObject(m, vc, results, true);
	    }
    </tbody>
