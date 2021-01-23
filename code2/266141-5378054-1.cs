    using System.Linq.Expressions;
        
    int reportID = 123456;
        	
    protected void gdvSignatureLines_Sorting(object sender, GridViewSortEventArgs e)
    {
       ReportOptionsBO reportOptionsBO = new ReportOptionsBO();
       List<T> ReportOptionsBOList =  reportOptionsBO.GetReportSignatureLineByReportId(reportId);
        
       if (ReportOptionsBOList != null)
       {
          var param = Expression.Parameter(typeof(T), e.SortExpression);
          var sortExpression = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);
        
          if (e.SortDirection == SortDirection.Ascending)
          {
             gdvSignatureLines.DataSource = ReportOptionsBOList.AsQueryable<T>().OrderBy(sortExpression);
          }
          else
          {
             gdvSignatureLines.DataSource = ReportOptionsBOList.AsQueryable<T>().OrderByDescending(sortExpression);
          }
        
          gdvSignatureLines.DataBind();
       }
    }
