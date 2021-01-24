    var optionCodes = res.factoryOption?.Select(c => new DecodedOptionCodesModel
	{
		OptionCode = c.oemCode
	});
	
	
	if (optionCodes != null) 
	{	
		vehicle.OptionCodes = new DecodedOptionCodesModel {
			OptionCode = string.Join(" ", optionCodes.Select(x => x.OptionCode).ToList())
		};
	}
