    var viewModel = new ClassifiedsBrowseViewModel
            {
                Category = categoryModel,
                Listings = categoryModel.Listings.OrderBy(c => {
                    switch (searchCriteria) {
                        case "Price" : return c.Price; break;
                        default: return c; break;
                    }
                }).ToList()
            };
