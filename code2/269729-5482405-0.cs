    DB.Insert().Into<DamageItems>()
        .Value(DamageItems.ImageIDColumn, imageID)
        .Value(DamageItems.CostColumn, cost)
        .Value(DamageItems.ImageColumn, image)
        .Execute();
