                        var referralsGrouping = db.Referrals
                            .Include(x => x.Doctor)
                            .Include(x => x.OfficeLocation)
                            .Where(x => (vm.OfficeLocationSelection == -1 ? true : x.OfficeLocationId == vm.OfficeLocationSelection) &&
                            string.IsNullOrEmpty(vm.SearchTerm) ? true : x.Doctor.Name.ToLower().Contains(vm.SearchTerm.ToLower()))
                            .GroupBy(x => x.Doctor);
    
                        if (!string.IsNullOrEmpty(vm.SortColumn))
                        {
                            if (vm.SortColumn == "YearToDate")
                            {
                                if (vm.SortDirection == SortDirectionType.Descending)
                                {
                                    referralsGrouping = referralsGrouping.OrderByDescending(x => x.Count(y => y.DoctorId == x.Key.Id && y.Date.Year == DateTime.Now.Year));
                                }
                                else
                                {
                                    referralsGrouping = referralsGrouping.OrderBy(x => x.Count(y => y.DoctorId == x.Key.Id && y.Date.Year == DateTime.Now.Year));
                                }
                            }
                        }
    
                        var referrals = referralsGrouping
                        .Select(x => new ReferralGridRowViewModel
                        {
                            DoctorName = x.Key.Name,
                            January = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 1 && y.Date.Year == DateTime.Now.Year).Count(),
                            February = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 2 && y.Date.Year == DateTime.Now.Year).Count(),
                            March = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 3 && y.Date.Year == DateTime.Now.Year).Count(),
                            April = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 4 && y.Date.Year == DateTime.Now.Year).Count(),
                            May = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 5 && y.Date.Year == DateTime.Now.Year).Count(),
                            June = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 6 && y.Date.Year == DateTime.Now.Year).Count(),
                            July = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 7 && y.Date.Year == DateTime.Now.Year).Count(),
                            August = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 8 && y.Date.Year == DateTime.Now.Year).Count(),
                            September = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 9 && y.Date.Year == DateTime.Now.Year).Count(),
                            October = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 10 && y.Date.Year == DateTime.Now.Year).Count(),
                            November = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 11 && y.Date.Year == DateTime.Now.Year).Count(),
                            December = x.Where(y => y.DoctorId == x.Key.Id && y.Date.Month == 12 && y.Date.Year == DateTime.Now.Year).Count()
                        });
                    if (!string.IsNullOrEmpty(vm.SortColumn))
                    {
                        if (vm.SortColumn == "DoctorName")
                        {
                            if (vm.SortDirection == SortDirectionType.Descending)
                            {
                                referrals = referrals.OrderByDescending(x => x.DoctorName);
                            }
                            else
                            {
                                referrals = referrals.OrderBy(x => x.DoctorName);
                            }
                        }
                        //other vm sort columns
                    }
