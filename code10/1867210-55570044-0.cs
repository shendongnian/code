    var items2 = DbContext.UutResult.Include(r=>r.StepNumericlimit1).ThenInclude(r=>r.StepNumericlimit2).Where(x =>
                    x.StartDateTime != null && (x.StartDateTime.Value.Date >= startDate &&
                                                x.StartDateTime.Value.Date <= endDate &&
                                                x.StationId == testerId)).Select(x => new TestResultItem()
                {
                    TesterId = (int) x.TestSocketIndex,
                    TesterType = x.StationId,
                    TestDateTime = (DateTime) x.StartDateTime,
                    TestResult = x.UutStatus,
                    PanelBarcode = x.BatchSerialNumber,
                    UutBarcode = x.UutStatus,
                    TestTimeSec = (double) x.ExecutionTime,
                    TestSteps = x.StepResult.Where(y => y.StepGroup == "Main").Select(y => new TestResultStepItem()
                    {
                        StepName = y.StepName,
                        Report = y.ReportText,
                        TestResult = y.Status,
                        UpperLimit = y.StepNumericlimit1.FirstOrDefault().StepNumericlimit2.FirstOrDefault().HighLimit.ToString(),
                        OrderId = (int)y.OrderNumber
                    }).ToList()
                }).ToList();
    
