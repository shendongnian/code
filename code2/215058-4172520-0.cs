    var viewModel = new ClassifiedsBrowseViewModel
            {
                Category = categoryModel,
                Listings = categoryModel.Listings.OrderBy(c => {
                    switch (searchCriteria) {
                        case "Price" : return c.Price;
                        default: return c;
                    }
                }).ToList()
            };
