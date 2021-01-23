    public ContinuityData GetSingleContinuityResult(string pin)
    {
        ContinuityData data;
        data = new ContinuityData();
        data.PinName = pin;
		
		XElement xtr = XElement.Load("path/to/your/xml/file");
		Func<string, string, string, double> getViData =
			(testName, pin, mode) =>
			Convert.ToDouble(
				xtr 
					.Descendants("Test")
					.Where(test => test.Descendants("Name")
									   .First().Value.Contains(testName))
					.Descendants("Pin")
					.Where(p => p.Descendants("Number")
									.First().Value == pin)
					.Descendants("VIPair")
					.Descendants(mode)
					.First().Value);
					
        data.PreVoltage = getViData("Pre Continuity", pin, "Voltage");
        data.PreCurrent = getViData("Pre Continuity", pin, "Current");
		
        data.PostCurrent = getViData("Post Continuity", pin, "Current");
        data.PostVoltage = getViData("Post Continuity", pin, "Voltage");
        return data;
    }
