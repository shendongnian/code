    return View(new GridContent<Entity>()
                {
                    Data = entityEnumeration, // your actual data
                    PageIndex = pageIndex,
                    TotalItems = totalItems,
                    TotalPages = totalItems / pageSize + 1
                });
