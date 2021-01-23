    foreach (var newCommission in newCommissions)
    {
        List<TutorCommission> TutorComs = newCommissions.GroupBy(g => g.Tutor).Select(s => new TutorCommission
        {
            CommissionAmount = s.Sum(u => u.CommissionAmount) * s.Key.TutorCommissionPercentage,
            TutorNoID = s.Key.TutorNoID
    
        }).ToList();
    
        db.TutorCommission.Add(newCommission);
        db.SaveChanges();
    }
