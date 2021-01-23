    bool isNullVersion=(Data.AgentVersion ?? "0.0.0.0") == "0.0.0.0";
    string policy= isNullVersion ? 
                               ResourcePolicyAvailSystemsLVI.m_nullString :
                               ResourcePolicyAvailSystemsLVI.unknown;
    if (Data.ResourcePolicy !=null) policy=Data.ResourcePolicy.Name;
    SubItems.Add(policy);
    SubItems.Add(isNullVersion ? 
                                ResourcePolicySystemsControl.m_nullVersion :
                                Data.AgentVersion
                );
    SubItems.Add(Data.AgentState.ToString());
