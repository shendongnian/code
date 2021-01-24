    In the productsView Model I just added this and it worked:
    private List<ProductView> PrepProducts(List<Product> dbProducts)
            {
                var productsView = new List<ProductView>();
                foreach (var product in dbProducts)
                {
                    productsView.Add(
                        new ProductView
                        {
                            Id = product.ID,
                            UserId = product.UserID,
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
                            Amenities = product.ProductAmenities.Select(x => new Models.ProductAmenity
                            {
                                Id = x.ID,
                                Amenity = new AmenityView
                                {
                                    Id = x.Amenity.ID,
                                    Itemname = x.Amenity.ItemName
                                }
                            }).ToList()
                          
                });
                return productsView;
            }
