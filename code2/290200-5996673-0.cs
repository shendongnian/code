    if (value != "")
        {
            string viewValue = value.Substring(0, value.IndexOf("|"));
            string viewType = value.Substring(value.IndexOf("|") + 1);
            UserType userType = summaryViewModel.SelectedUserType;
            sSummaryViewModel.ReportFrame.SourceURL =
                WebPathHelper.MapUrlFromRoot(
                    string.Format("Reporting/Summary.aspx?beginDate={0}&endDate={1}&Id={2}&viewType={3}&userType={4}",summaryViewModel.BeginDate, summaryViewModel.EndDate, viewValue,  viewType, userType));
        }
