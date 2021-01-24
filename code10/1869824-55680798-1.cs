    var foodViewModels = db.Ratings.OrderByDescending(e => e.Rate)
        .Select(e => new FoodViewModel
        {
            ID = e.Food.ID,
            Name = e.Food.Name,
            Price = e.Food.Price,
            DateTime Date_Time = e.Food.Date_Time,
            FoodDescription = e.Food.FoodDescription,
            CookingTime = e.Food.CookingTime,
            UploadedBy = e.Food.UploadedBy
        }).Distinct().ToList();
    
    return Request.HttpCreateResponse(foodViewModels);
