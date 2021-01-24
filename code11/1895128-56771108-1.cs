    var brand = db.Brands.ToArray().Select(x => new BrandVM(x));
                    foreach (var item in listOfBicycleVM)
                    {
                        if( brand.Any(x => x.Id == item.BrandId))
                        {
                            item.Brand = brand.First(c => c.Id == item.BrandId).Name;
                        }
                    }
