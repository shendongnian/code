    public ActionResult Products()
            {
                var products = new List<BarangsViewModel>();
                for (int i = 1; i < 5; i++)
                {
                    var obj = new BarangsViewModel
                    {
                        IdBarang = i,
                        NamaBarang = $"This is job {i}",
                        HargaBarang = i                    
                    };
                    products.Add(obj);
                }
                
                return View("Products", products);
            }
 
               [HttpPost]
                public IActionResult Products(List<BarangsViewModel> model)
                {
                    return RedirectToAction("Index");
                }
