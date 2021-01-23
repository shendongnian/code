    listOfCustomer.GroupBy(c => new { c.ServiceStartDate.Year, c.ServiceStartDate.Month })
                  .Select(group => new DashboardCustomerConversions()
                                    {
                                        Month = string.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month), group.Key.Year),
                                        Trials = group.Count(),
                                        Purchased = group.Count(c => c.BillingStartDate.HasValue)
                                    });
