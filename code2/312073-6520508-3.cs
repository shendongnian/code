    var stats =
        (from est in test.Cast<Estimation>()
        group est by est.code into gEst
        let allItems = gEst.SelectMany(est => est.EstimationItems).Cast<EstimationItem>()
        select new TestingUI
            {
                Code = gEst.Key,
                Quantity = gEst.Count(),
                Total = gEst.Sum(item => item.Price * item.Quantity)
            }).ToList();
