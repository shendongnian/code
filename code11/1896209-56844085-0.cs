    var query = context.Solutions
                    .Select(s => new SolutionDto {
                        Id = s.Id,
                        Name = s.Name,
                        Description = s.Description,
                        Category = new CategoryDto {
                            Id = s.Category.Id,
                            Name = s.Category.Name
                        },
                        Views = s.SolutionViews.Count()
                    });
