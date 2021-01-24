	public Results GetResults()
	{
		var term = dc.AgentTerm(Agentcode).ToList();
		var hosp = dc.AgentHospCashPlan(Agentcode).ToList();
		
		return new Results { AgentTerms = term, AgentHospCashPlan = hosp };
	}
