          // myMethode Function
            reportViewer.Reset();
            reportViewer.LocalReport.DataSources.Add(dataSource);
            reportViewer.LocalReport.ReportPath = "Report Path";
            reportViewer.LocalReport.SubreportProcessing += 
                                     LocalReportOnSubreportProcessing;
            reportViewer.LocalReport.Refresh();
       private void LocalReportOnSubreportProcessing(object sender, 
                                                     SubreportProcessingEventArgs e)
            {
                //Following Code Is just a Sample 
                switch (e.ReportPath)
                {
                    case "ExamResult1To3Scores":
                        {
                            var ranksReportDataSource = new ReportDataSource
                            {
                                Name = "ExamResult1To3",
                                Value = GetCandidatesExamResultGuidanceRequest
                            };
                            e.DataSources.Add(ranksReportDataSource);
                            break;
                        }
    
                    case "ExamResult1To3Chart":
                        {
                            var levelRank = 
                                GetCandidatesRequest.First().Guidance1To3ChartData;
    
                            var chartReportDataSource = new ReportDataSource
                            {
                                Name = "ExamResult1To3Chart",
                                Value = levelRank
                            };
                            e.DataSources.Add(chartReportDataSource);
                            break;
                        }
