            IEnumerable<TutorCommission> tutorsCommissionsAlt = enrollments // Take the enrollments
                .GroupJoin( // This will group enrollments by the tutor
                    tutorCommissionPercentages, // Join with the tutor's commission percentages.
                    e => e.TutorNoID, // Use tutorNoID for left Key
                    tcp => tcp.TutorNoID, // ... and right key
                    (e, tcp) => new TutorCommission // Create entry which is the tutor and his total commission
                    {
                        TutorNoID = e.TutorNoID,
                        CommissionAmount = (long) tcp.Sum(c => c.CommissionPercentage * e.MonthlyFee)
                    });
