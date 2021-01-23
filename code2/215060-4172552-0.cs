    switch(searchCriteria)
                {
                    case "Price":
                        viewModel.Listings = categoryModel.Listings.OrderBy(c => c.Price).ToList()
                        break;
                    case default:
                        viewModel.Listings = categoryModel.Listings.OrderBy(c => c.SomeOtherField).ToList()
                        break;
                }
