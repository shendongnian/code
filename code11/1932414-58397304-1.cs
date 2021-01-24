    namespace BB360
    {
    	public partial class Sql
    	{
    		public const string GetDocUnderReviewDetails = @"
    
            select 
                DocBudgetId, 
                DocNumber, 
                ReviewBy, 
                convert(varchar, ReviewOn, 101) as ReviewOn, 
                isnull(ReviewComment, '') as ReviewComment 
                from DocBudgetReview 
                --where DocBudgetId = @DocBudgetId
                where DocNumber = @DocNumber
                order by ReviewOn desc   
            ";
    	}
    }
