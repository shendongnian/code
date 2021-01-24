    class AgentTerm : IMyInterface
    {
         public AgentTerm_Result TermResult {get; set;}
         public int Id => this.TermResult.TermResultId;
         public string Name => this.TermResult.TermResultName;
