    List<StatePlan> planTypes = (from ppt in context.PlanPlanTypes
                                                 join pt in context.PlanTypes on ppt.PlanTypeRowID equals pt.PlanTypeRowID
                                                 join ppts in context.PlanPlanTypeStates on ppt.PlanPlanTypeRowID equals ppts.PlanPlanTypeRowID
                                                 join p in context.Plans on ppt.PlanRowID equals p.PlanRowID
                                                 where ppts.StateCode == stateCode
                                                 where p.IsActive == true
                                                 select new StatePlan
                                                 {   
                                                     PlanID = p.PlanRowID,
                                                     StateCode = stateCode,
                                                     Name = p.Name,
                                                     Description = p.Description,
                                                     Disclaimer = p.Disclaimer,
                                                     Sequence = p.DisplaySequence,
                                                     //Rates = GetRates(p.PlanRowID),
                                                     //Types = GetPlanTypes(p.PlanRowID, stateCode)
                                                 })
    											 .GroupBy(g => g.Name)
    											 .Select(s => s.First())
    											 .ToList();
                return planTypes;
