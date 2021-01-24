csharp
public ProjectBudgetSummaryProfile()
{
   CreateMap<ProjectBudgetSummaryViewModel, HdsBudgetSummary>()
      ReverseMap();
   CreateMap<ProjectBudgetSummaryViewModel, CdsBudgetSummary>()
      ReverseMap();
}
