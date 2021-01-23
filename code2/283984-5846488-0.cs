     foreach (var entity in xdoc.Descendants(atom + "entry")) {
                            var properties = entity.Element(atom + "content").Element(m + "properties");
                            var category = new CategoryModel() {
                                Id = Convert.ToInt32(properties.Element(d + "CategoryID").Value),
                                Name = properties.Element(d + "CategoryName").Value,
                                Description = properties.Element(d + "Description").Value,
                            };
                            Items.Add(category);
                        }
