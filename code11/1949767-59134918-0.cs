                if (!ModelState.IsValid)
                {
                    ViewBag.Message = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));                    
                    return View(model);
                }
