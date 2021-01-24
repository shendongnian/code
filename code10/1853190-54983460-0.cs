    interface IMyInterface
    {
         // Properties that are both in AgentTerm_Result and in AgentHospCashPlan
         int Id {get;}
         string Name {get;}
    }
    class AgentTerm_Result : IMyInterface {...}
    class AgentHospCashPlan : IMyInterface{...}
    var result = terms.Cast<IMyInterface>()
         .Concat(hosps.Cast<IMyInterface>();
