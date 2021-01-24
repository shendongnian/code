    Mapper.Initialize(config =>
    {
         config.CreateMap<Sweet, FoodItem>()
            .ForMember(f => f.IsSpicy, o => o.Ignore())
            .ForMember(f => f.SpiceLevel, o => o.Ignore());
         config.CreateMap<Spicy, FoodItem>()
            .ForMember(f => f.IsSweet, o => o.Ignore())
            .ForMember(f => f.SweetLevel, o => o.Ignore());
    });
    // ...
    var foodItems = Mapper.Map<List<FoodItem>>(listOfSweetItems);
    foodItems = foodItems
       .Zip(listOfSpicyItems, (foodItem, spicyItem) => Mapper.Map(spicyItem, foodItem))
       .ToList();
