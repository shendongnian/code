     public List<SalaryTracker> GetSalaryTrackerOrderByGenerationDate(int tutorId)
        {
            List<SalaryTracker> salary = new List<SalaryTracker>();
            using (leDataContext db = new leDataContext())
            {
                try
                {
                    return (from s in db.SalaryTrackers
                            where s.StaffId == 2 && s.PaymentDate == null
                            group s by s.GenerationDate into g
                            select new SalaryTracker 
                            { 
                                GenerationDate = g.Key, 
                                SalaryAmount = g.Sum(p => p.SalaryAmount) 
                            });                
                }
                catch (Exception ex)
                {
                    Logger.Error(typeof(SalaryTracker), ex.ToString());
                    throw;
                }                    
            }
        }
