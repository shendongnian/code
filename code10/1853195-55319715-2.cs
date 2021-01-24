	public (List<AgentTerm_Result>, List<AgentHospCashPlan_Result>) GetResults()
	{
		var Agentcode = "";
	
		var term = dc.AgentTerm(Agentcode).ToList();
		var hosp = dc.AgentHospCashPlan(Agentcode).ToList();
		
		return (term, hosp);
	}	
