List<OperationsReviewLevelResult> results = new List<OperationsReviewLevelResult>();
foreach (var approval in OperationsReviewers.ApprovalItems)
{
     var result = new OperationsReviewLevelResult();
     result.ApproverName = approval.Results.FirstOrDefault()?.Name ?? "";
     result.ReviewLevel = approval.Name;
     result.Comment = approval.Results.FirstOrDefault()?.Comments ?? "";
     results.Add(result);
}
If it's possible other parts of the results could be null, you can go the full paranoid route
List<OperationsReviewLevelResult> results = new List<OperationsReviewLevelResult>();
foreach (var approval in OperationsReviewers.ApprovalItems)
{
     var result = new OperationsReviewLevelResult();
     result.ApproverName = approval?.Results?.FirstOrDefault()?.Name ?? "";
     result.ReviewLevel = approval?.Name;
     result.Comment = approval?.Results?.FirstOrDefault()?.Comments ?? "";
     results.Add(result);
}
And paranoid and LINQ-ified:
var results = OperationsReviewers.ApprovalItems
    .Select(approval => new OperationsReviewLevelResult
    {
        ApproverName = approval?.Results?.FirstOrDefault()?.Name ?? "",
        ReviewLevel = approval?.Name,
        Comment = approval?.Results?.FirstOrDefault()?.Comments ?? ""
    }
    .ToList();
