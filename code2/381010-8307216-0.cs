    var items = baseReportDefinitions.GroupJoin(
                    inputReportDefinitions,
                    firstSelector => new {
                                             firstSelector.ParentName,
                                             firstSelector.ReportName
                                         },
                    secondSelector => new {
                                             secondSelector.ParentName,
                                             secondSelector.ReportName
                                          },
                    (baseReport, inputCollection) => new {
                                                          baseReport,
                                                          inputCollection
                                                         })
                    .SelectMany(grp => grp.inputCollection.DefaultIfEmpty(),
                    (col, inputReport) => new
                                       {
                                           Base = col.baseReport,
                                           Input = inputReport
                                        });
