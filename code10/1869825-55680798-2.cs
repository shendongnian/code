    var foodViewModels = db.Foods.OrderByDescending(f => f.Ratings.Max(r => r.Rate))
        .Select(f => new FoodViewModel
        {
            ID = f.ID,
            Name = f.Name,
            Price = f.Price,
            DateTime Date_Time = f.Date_Time,
            FoodDescription = f.FoodDescription,
            CookingTime = f.CookingTime,
            UploadedBy = f.UploadedBy
        }).ToList();
