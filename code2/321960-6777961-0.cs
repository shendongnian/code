    if(Data.ResourcePolicy == null) {
      if (Data.AgentVersion == null) {
        SubItems.Add(ResourcePolicyAvailSystemsLVI.m_nullString);
      } else {
        SubItems.Add(ResourcePolicyAvailSystemsLVI.unknown);
      }
    } else { 
      SubItems.Add(Data.ResourcePolicy.Name);
    }
    if (Data.AgentVersion == null || Data.AgentVersion.Equals("0.0.0.0")) {
       SubItems.Add(ResourcePolicySystemsControl.m_nullVersion);
    } else {
      SubItems.Add(Data.AgentVersion);
    }
    SubItems.Add(Data.AgentState.ToString());
