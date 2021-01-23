        public ViewResult List(string category, int page = 1)
        {
            var productsToShow = (category == null)
                    ? productsRepository.Products
                    : productsRepository.Products.Where(x => x.Category == category);
            var viewModel = new ProductsListViewModel {
                Products = productsToShow.Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = productsToShow.Count()
                },
                CurrentCategory = category
            };
            return View(viewModel); // Passed to view as ViewData.Model (or simply Model)
        }
