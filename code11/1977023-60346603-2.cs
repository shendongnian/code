        [HttpPost]  
        public IActionResult Daily(Daily dailyReport)  
        {  
            var dr = new ReportDaily();
            var rc = new ReportDailyCriteria();
            dr.Preview(rc, IntPtr.Zero, out Notification notification);
            if (notification.HasErrors) 
            {
                return Json(new
                {
                    success = false,
                    message = notification.GetConcatenatedErrorMessage(Environment.NewLine + Environment.NewLine)
                });
            }
            return Json(new { success = true });
        }
