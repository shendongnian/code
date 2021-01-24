    public static string SetAvgPeriodDays(int userId)
    {
        using(var ctx = EfHelper.GetContext())
        {
            var service = new AveragePeriodDaysService(ctx);
        
            try
            {
                return service.SetAveragePeriodDays(userId);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
