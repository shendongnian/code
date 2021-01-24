    if (IsActingAsDelegate && userProfile.ProducerProfile.IsInactiveProducer)
    {
        variableProducerAgreements = userProfile.ProducerProfile.ProducerAgreements.FindAll(ag => ag.IsActive && ag.IsVariableBranchContract);
    }
    else
    {
        variableProducerAgreements = userProfile.ProducerProfile.ActiveAgreements.Where(a => a.IsVariableContract);
    }
