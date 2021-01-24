      var productsView = dbProducts.Select(x => new PersonViewModel {
                                Id = product.ID,
                                Category = product.Category,
                                Address = product.Location,
                                Amount = product.Price,
                                Beds = product.Bathroom,
                                Baths = product.Bedroom,
                                Area = product.Area,
                                Parking = product.Parking,
                                ParkingSpot = product.ParkingSpot,
                                Description = product.Description,
                                Term = product.Term,
                                UserId = product.UserID,
                                ProductAmenities = product.ProductAmenities.Select(//use viewmodel to cast it, like to PersonViewModel)
        
                    }).ToList();
    
  
