            var month = DateTime.Now.ToString("MMMM");
            var enrolments = new List<Enrollment>();
            enrolments.Add(new Enrollment { TutorNoID = 1, MonthlyFee = 1500 });
            enrolments.Add(new Enrollment { TutorNoID = 1, MonthlyFee = 4500 });
            var tutor = new List<Tutor>();
            tutor.Add(new Tutor { TutorNoID = 1, TutorCommissionPercentage = 0.5 });
            IEnumerable<TutorCommission> tutorsCommissionsAlt = tutor.GroupJoin(enrolments,
                    tut => tut.TutorNoID, 
                    enr => enr.TutorNoID,
                    (tut, enr) => new TutorCommission // Create entry which is the tutor and his total commission
                    {
                        TutorNoID = tut.TutorNoID,
                        CommissionAmount = (long)enr.Sum(c => c.MonthlyFee * tut.TutorCommissionPercentage),
                        CommissionMonth = month,  // string constant 
                        CommissionStatus = "Unpaid",
                    });
            foreach (var com in tutorsCommissionsAlt)
            {
                Console.WriteLine(com.CommissionAmount);
            }
    // Output: 3000
