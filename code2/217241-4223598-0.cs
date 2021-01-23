        var categoryModel = AfvClassifiedsDB.Categories.Include("Listings")
                .First(c => c.Title == categoryName);
            var viewModel = new ClassifiedsBrowseViewModel
            {
                Category = categoryModel,
                Listings = categoryModel.Listings.OrderBy(c => c.Price).ToList(),
                DateListed = categoryModel.Listings.DateListed.ToString("("MMMM dd, yyyy")
            };
