    var task = Task.Run(() =>
    {
        var promotionStatus = GetPromotionStatus(promotion).Result;
        var newPromotion = new Promotion
        {
            Id = promotion.Id,
            Name = promotion.Name,
            Code = promotion.Code,
            StatusId = promotionStatus
        };
        outputPromotions.Add(newPromotion);
    });
