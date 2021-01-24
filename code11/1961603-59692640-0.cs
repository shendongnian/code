     public List<Entities.WorkOrderFeedbackDetails> GetPendingFeedBack(Entities.Shared.Requests.BaseRequest baseRequest)
        {
            Database db = new Database();
            List<Entities.WorkOrderFeedbackDetails> workOrders = new List<WorkOrderFeedbackDetails>();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"[dbo].[UspGetSiteLevelPendingFeedBack]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TokenID", SqlDbType.UniqueIdentifier).Value = baseRequest.tokenId;
                    DataSet ds = new DataSet();
                    ds = db.ExecuteProc(cmd);
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Entities.WorkOrderFeedbackDetails feedback = new Entities.WorkOrderFeedbackDetails
                            {
                                //Case Details
                                WorkOrderID = db.GetGuidValue(dr, "WorkOrderID"),
                                WorkSurveyID = db.GetGuidValue(dr, "WorkSurveyID"),
                                WorkOrderNumber = db.GetStringValue(dr, "WorkOrderNumber"),
                                WorkDescription = db.GetStringValue(dr, "WorkDescription"),
                                CaseID = db.GetStringValue(dr, "CaseID"),
                                SurveyID = db.GetGuidValue(dr, "SurveyID"),
                                
                            };
                            foreach (DataRow dr2 in ds.Tables[0]
                                .Select("WorkOrderID = '" + db.GetGuidValue(dr, "WorkOrderID") + "'" +
                                " AND WorkSurveyID='" + db.GetGuidValue(dr, "WorkSurveyID") + "'"))
                            {
                                Entities.Questions questions = new Questions
                                {
                                    SurveyQuestionnarieID = db.GetGuidValue(dr2, "SurveyQuestionnarieID"),
                                    QuestionDescription = db.GetStringValue(dr2, "QuestionDescription"),
                                    ResponseSetID = db.GetGuidValue(dr2, "ResponseSetID"),
                                    FeedBackType = db.GetIntValue(dr2, "FeedbackType"),
                                    IsMandatory = db.GetIntValue(dr2, "IsMandatory"),
                                    StepNumber = db.GetIntValue(dr2, "StepNumber"),
                                    IsCommentBox = db.GetIntValue(dr2, "IsCommentBox"),
                                    SurveyID = db.GetGuidValue(dr2, "SurveyID")
                                };
                                foreach (DataRow dr3 in ds.Tables[0]
                               .Select("SurveyQuestionnarieID='" + db.GetGuidValue(dr2, "SurveyQuestionnarieID") + "'"))
                                {
                                    Entities.Options options = new Options
                                    {
                                        DisplayOrder = db.GetIntValue(dr3, "DisplayOrder"),
                                        OptionID = db.GetGuidValue(dr3, "OptionID"),
                                        OptionName = db.GetStringValue(dr3, "OptionName"),
                                        ResponseSetID = db.GetGuidValue(dr3, "ResponseSetID"),
                                        ChecklistResponseSetID = db.GetGuidValue(dr3, "ChecklistResponseSetID")
                                    };
                                  //  if (!questions.Options.Any(item => item.OptionID == options.OptionID))
                                        questions.Options.Add(options);
                                    
                                }
                                if (!feedback.Feedbackquestions.Any(item => item.SurveyQuestionnarieID == questions.SurveyQuestionnarieID))
                                    feedback.Feedbackquestions.Add(questions);
                            }
                                if (!workOrders.Any(item => item.WorkSurveyID == feedback.WorkSurveyID))
                                workOrders.Add(feedback);
                        }
                        if (workOrders.Count == 0)
                        {
                            workOrders = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                db.LogError(new CommonEntities.ErrorLog
                {
                    errorTitle = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    reportedDateTime = DateTime.Now,
                    tokenId = baseRequest.tokenId,
                    errorDescription = ex.ToString()
                });
            }
            return workOrders;
        }
