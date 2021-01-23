    public static Guid GetCurrentWorkerByType(int enrollmentID, int staffTypeID)
    {
     using (var context = CmoDataContext.Create())
     {
      IQueryable<tblWorkerHistory> tWorkHist = context.GetTable<tblWorkerHistory>();
    	var guid = (tWorkHist.Where(workHist => (workHist.EnrollmentID == enrollmentID) && 
						(workHist.tblStaff.StaffTypeID == staffTypeID) &&(workHist.EndDate == null || workHist.EndDate > DateTime.Now))
			.Select(workHist => workHist.Worker)
         ///####NOTICE THE USE OF FirstOrDefault
			).FirstOrDefault();
 		return (guid.HasValue)?guid.Value:Guid.Empty
 		}
    }
