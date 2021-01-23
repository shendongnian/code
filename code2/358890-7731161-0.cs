    ...
    from enrolment in enrolments
                         select new TutorCommission()
                         {
                             CommissionAmount = enrolment.MonthlyFee,
                             CommissionMonth = month,  // string constant 
                             CommissionStatus = "Unpaid",
                             Tutor = new Tutor { TutorNoID = enrolment.Tutor.TutorNoID, TutorCommissionPercentage = enrolment.Tutor.TutorCommissionPercentage }
                         };
