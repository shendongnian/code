                    if (query.Any())
                    {
                        if (query.Where(x => x.VelosiReportNo.Contains(OfficeStationCombination)).Any())
                        {
                            VelosiReportNo = query.Where(x => x.VelosiReportNo.Contains(OfficeStationCombination)).OrderByDescending(x => x.InspectionReportID).FirstOrDefault().VelosiReportNo;
                        }
                        else
                        {
                            VelosiReportNo = null;
                        }
                        
                    }
