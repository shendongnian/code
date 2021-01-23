    var searchCritera = ListingOrderingOptions.Price;
    
    var viewModel = new ClassifiedsBrowseViewModel
            {
                Category = categoryModel,
                Listings = categoryModel.Listings.WithListingOrder(searchCriteria)
                }).ToList()
            };
