       private List<BPAlert> filterErrorsAsync(List<BPAlert> allAlerts)
        {
            List<BPAlert> temp = new List<BPAlert>(); //copy into new list
            foreach (BPAlert alert in allAlerts)
            {
                if (alert.AlertTypeId == (int)BusinessReportCustomTextType.CustomerReviews)
                {
                    temp.Add(alert);
                }
            }
            return temp;
        }
