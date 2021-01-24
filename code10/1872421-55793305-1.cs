    var optionCodes = res.factoryOption?.Select(c => c.oemCode);
		
	if (optionCodes != null) 
	{	
		vehicle.OptionCodes = new DecodedOptionCodesModel {
			OptionCode = string.Join(" ", optionCodes.ToList())
		};
	}
