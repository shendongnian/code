    List<CarViewModel> FeedItems = (from carsXdoc in xdoc.Descendants("Cars")
                                    select new CarViewModel()
                                    {
                                        Name = carsXdoc.Element("Name").Value,
                                        Model = carsXdoc.Element("Model").Value,
                                        Parts = ToObservableCollection(from part in carsXdoc.Element("Parts").Descendants("Part")
                                                                       select new PartViewModel()
                                                                       {
                                                                           PartName = part.Element("PartName").Value,
                                                                           PartType = part.Element("PartType").Value,
                                                                       })
                                    }).ToList();
