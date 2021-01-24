    public IActionResult AddAttribute(string index)
        {
            ViewBag.Index = index;
            ProviderViewModel provider = new ProviderViewModel {
                Attributes=new List<AttributeViewModel>()
            };
            provider.Attributes.Add(new AttributeViewModel
            {
                Guid = Guid.NewGuid().ToString()
            });
            return PartialView("_ProviderAttribute", provider);
        }
