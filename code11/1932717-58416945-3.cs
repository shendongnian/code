    public Feedback vStageReqFields(Guid NextStageID, Guid PipelineID) {
        Feedback feedback = new Feedback();
        List<string> required = new List<string>();
        List<string> errors = new List<string>();
        StringBuilder msg = new StringBuilder();
        try {
            //Get a list of Validations needed before advancing Stage...
            var validations = db.PipelineStageRequiredFields.Where(w => w.StageID == NextStageID);
            //If Validations exist, start validatiing...
            if (validations.Any()) {
                foreach (var field in validations) {
                    var className = field.RefelectionClass;
                    object model = null;
                    //Switch Statement for Reflection Class to Check Property Value...
                    switch (className) {
                        case "Domain.Pipeline.Pipeline":
                            model = db.Pipelines.FirstOrDefault(p => p.ID == PipelineID);
                            break;
                        case "Domain.Pipeline.Billing":
                            model = db.Billings.Where(w => w.PipelineID == PipelineID).OrderByDescending(o => o.EffectiveDate).FirstOrDefault();
                            break;
                        default:
                            errors.Add("Could not find any Data in the " + className + " table for this Pipeline: '" + PipelineID.ToString() + "'");
                            continue;
                    }
                    validate(field, PipelineID, model, required, errors);
                }
                if (required.Any()) {
                    msg.Append("The following fields are required: ")
                        .AppendLine(string.Join(", ", required));
                }
                if (errors.Any()) {
                    msg.AppendLine(string.Join(Environment.NewLine, errors));
                }
            }
            if (msg.Length > 0) {
                feedback.Success = false;
                feedback.Type = FeedbackType.Error;
                feedback.SuccessMsg = msg.ToString();
            } else {
                feedback.Success = true;
                feedback.Type = FeedbackType.Success;
                feedback.SuccessMsg = "Success! There are no required fields for the next stage.";
            }
        } catch (Exception ex) {
            feedback.Success = false;
            feedback.Type = FeedbackType.Error;
            feedback.SuccessMsg = ITool.GetExceptionDetails(ex);
        }
        return feedback;
    }
    
