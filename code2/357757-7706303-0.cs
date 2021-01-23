            IEnumerable<TutorCommission> tutorsCommissions =
                from enrollment in enrollments // Take the enrollments
                join tutorsCommissionPercentage in tutorCommissionPercentages // Join with the tutor's commission percentages.
                    on enrollment.TutorNoID equals tutorsCommissionPercentage.TutorNoID
                group enrollment by new { enrollment.TutorNoID, tutorsCommissionPercentage.CommissionPercentage } into enrollmentsAndCommissionByTutor // group enrollments and commission by the tutor
                select new TutorCommission
                {
                    TutorNoID = enrollmentsAndCommissionByTutor.Key.TutorNoID, // the grouping which is the tutor
                    CommissionAmount = (long) enrollmentsAndCommissionByTutor.Sum(e => e.MonthlyFee * enrollmentsAndCommissionByTutor.Key.CommissionPercentage)
                };
