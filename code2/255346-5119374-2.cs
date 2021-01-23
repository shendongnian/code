    public List<SalaryTracker> GetSalaryTrackerOrderByGenerationDate(int tutorId)
    {
        using (var db = new leDataContext())
        {
            try
            {
                return (
                    from s in db.SalaryTrackers
                    where s.StaffId == 2 && s.PaymentDate == null
                    group s by s.GenerationDate into g
                    select new SalaryTracker 
                    { 
                        GenerationDate = g.Key, 
                        SalaryAmount = g.Sum(p => p.SalaryAmount) 
                    }).ToList();
            }
            catch (Exception ex)
            {
                Logger.Error(typeof(SalaryTracker), ex.ToString());
                throw;
            }
        }
    }
