    var TeamLeadAuditsAndQuality =unitofwork.AuditNewRepository.SQLQuery<SPTotalAuditAndQualityOfOfMonthByTeamLead_Result>("SPTotalAuditAndQualityOfOfMonthByTeamLead").ToList();
                var TeamLeadFeedBacks = unitofwork.AuditNewRepository.SQLQuery<SPTotalFeedBackOfOfMonthByTeamLead_Result>("SPTotalFeedBackOfOfMonthByTeamLead").ToList();
                    for(var i=0 ;i < TeamLeadAuditsAndQuality.Count; i++)
                        {
                            TeamLeadMonthlyResult Result = new TeamLeadMonthlyResult();
                            Result.TeamLead = TeamLeadAuditsAndQuality[i].TeamLead;
                            Result.MonthlyAudits = Convert.ToInt32(TeamLeadAuditsAndQuality[i].TotalAuditsOfCRU);
                            Result.MonthlyQuality = TeamLeadAuditsAndQuality[i].Average;
            
    if(i<= TeamLeadFeedBacks.Count)                        
                                Result.MonthlyFeedbacks = Convert.ToInt32(TeamLeadFeedBacks[i].TotalFeedbackOfCRU);
                            
                            List.Add(Result);
                        }
                        model.TeamLeadMonthlyResultVMList = List;
            
                        return View(model);
                    }
