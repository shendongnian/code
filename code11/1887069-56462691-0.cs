    // GroupJoin Fabrics with some of their OrderPlans:
    var result = dbContext.Fabrics
        .GroupJoin(dbContext.OrderPlans.Where(orderPlan => ...)
        fabric => fabric.Id,              // from each Fabric take the primary key
        orderPlan => orderPlan.FabricId,  // from each OrderPlan take the foreign key
        // ResultSelector: take every Fabric with all his matching OrderPlans to make one new object:
        (fabric, orderPlansOfthisFabric) => new
        {
            // Select the Fabric properties you want
            Id = fabric.Id,
            Name = fabric.Name,
            Type = fabric.Type,
            OrderPlans = orderPlansOfThisFabric.Select(orderPlan => new
            {
                 // Select the OrderPlan properties you want:
                 Width = orderPlan.Width,
                 Gsm = orderPlan.Gsm,
            }
            // Weight: calculate the sum of all OrderPlans of this Fabric:
            Weight = orderPlansOfThisFabric
                     .Select(orderPlan => orderPlan.Weight)
                     .Sum(),
        });
