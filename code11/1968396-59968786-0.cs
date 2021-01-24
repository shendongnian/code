       foreach (var approval in OperationsReviewers.ApprovalItems)
         results.Add(new OperationsReviewLevelResult() {
           ApproverName = approval.Results.FirstOrDefault()?.Name ?? "",
           ReviewLevel  = approval.Name,
           Comment      = approval.Results.FirstOrDefault()?.Comments ?? "",
         });
