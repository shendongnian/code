            resultSummaryViewModel.Value = value;
            resultSummaryViewModel.ReportFrame = new FramedViewModel();
            if(value !="")
            {
                string viewValue = value.Substring(0, value.IndexOf("|"));
                string viewType = value.Substring(value.IndexOf("|") + 1);
                resultSummaryViewModel.ReportFrame.SourceURL =
                    WebPathHelper.MapUrlFromRoot(
                        string.Format(
                            "Reporting/ResultSummary.aspx?beginDate={0}&endDate={1}&Id={2}&viewType={3}",
                            resultSummaryViewModel.BeginDate, resultSummaryViewModel.EndDate, viewValue,
                            viewType));
            }
            var viewData = new Dictionary<string, string>();
            viewData.Add("Schools", "|allschools");
            viewData.Add("Classes", "|allclasses");
