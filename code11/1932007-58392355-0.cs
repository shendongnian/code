        private List<ActivityLogs> GetSearchResult()
        {
            DateTime fromDate = Convert.ToDateTime(TempData["fromDate"].ToString());
            DateTime toDate = Convert.ToDateTime(TempData["toDate"].ToString());
            string operation = TempData["operation"] as string;
            string userName = TempData["userName"] as string;
            string pageName = TempData["pageName"] as string;
            TempData.Keep();
            if (fromDate == default(DateTime) && toDate == default(DateTime))
            {
                if (operation == null && userName == null && pageName == null)
                {
                    return db.ActivityLogs.Include(x => x.Pages).ToList();
                }
            }
            else
            {
                if (operation != null && userName == null && pageName == null)
                {
                    return db.ActivityLogs.Include(x => x.Pages).OrderByDescending(x => x.ActivityLogDateTime).Where(x => x.ActivityLogDateTime >= fromDate && x.ActivityLogDateTime <= toDate
                    && x.Operation.Contains(operation)).ToList();
                }
                else if (operation == null && userName != null && pageName == null)
                {
                    return db.ActivityLogs.Include(x => x.Pages).OrderByDescending(x => x.ActivityLogDateTime).Where(x => x.ActivityLogDateTime >= fromDate && x.ActivityLogDateTime <= toDate
                    && x.Username.Contains(userName)).ToList();
                }
                else if (operation == null & userName == null && pageName != null)
                {
                    return db.ActivityLogs.Include(x => x.Pages).OrderByDescending(x => x.ActivityLogDateTime).Where(x => x.ActivityLogDateTime >= fromDate && x.ActivityLogDateTime <= toDate
                    && x.Pages.PageName.Contains(userName)).ToList();
                }
                else if (operation != null && userName != null && pageName == null)
                {
                    return db.ActivityLogs.Include(x => x.Pages).OrderByDescending(x => x.ActivityLogDateTime).Where(x => x.ActivityLogDateTime >= fromDate && x.ActivityLogDateTime <= toDate
                    && x.Username.Contains(operation) && x.Username.Contains(userName)).ToList();
                }
                else if (operation != null && userName == null && pageName != null)
                {
                    return db.ActivityLogs.Include(x => x.Pages).OrderByDescending(x => x.ActivityLogDateTime).Where(x => x.ActivityLogDateTime >= fromDate && x.ActivityLogDateTime <= toDate
                    && x.Operation.Contains(operation) && x.Pages.PageName.Contains(pageName)).ToList();
                }
                else if (operation == null && userName != null && pageName != null)
                {
                    return db.ActivityLogs.Include(x => x.Pages).OrderByDescending(x => x.ActivityLogDateTime).Where(x => x.ActivityLogDateTime >= fromDate && x.ActivityLogDateTime <= toDate
                    && x.Username.Contains(userName) && x.Pages.PageName.Contains(pageName)).ToList();
                }
                else if (operation != null && userName != null && pageName != null)
                {
                    return db.ActivityLogs.Include(x => x.Pages).OrderByDescending(x => x.ActivityLogDateTime).Where(x => x.ActivityLogDateTime >= fromDate && x.ActivityLogDateTime <= toDate
                    && x.Operation.Contains(operation) && x.Username.Contains(userName) && x.Pages.PageName.Contains(pageName)).ToList();
                }
                else if(operation == null && userName == null && pageName == null)
                {
                    return db.ActivityLogs.Include(x => x.Pages).OrderByDescending(x => x.ActivityLogDateTime).Where(x => x.ActivityLogDateTime >= fromDate && x.ActivityLogDateTime <= toDate).ToList();
                }
            }
            return db.ActivityLogs.OrderByDescending(x => x.ActivityLogDateTime).ToList();
        }
