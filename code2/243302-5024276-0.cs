        [HttpPost]
        public ActionResult Create(FormCollection form )//Models.MVCOrder newOrder)
        {
            MVC.Models.MVCOrder ord = Models.MVCOrder.Instance.CreateBlankOrder();
            //Update order with simple types (e.g. Quantity)
            if (TryUpdateModel<MVC.Models.MVCOrder>(ord, form.ToValueProvider()))
            {
                ord.Product = Models.MVCProduct.Instance.ProductList.Find(p => p.Id == int.Parse(form.GetValue("ProductList").AttemptedValue));
                ord.Attribute = Models.MVCAttribute.Instance.AttributeList.Find(a => a.Id == int.Parse(form.GetValue("attributeId").AttemptedValue));
                UpdateModel(ord);
                return RedirectToAction("Index");
            }
            else
            {
                return View(ord);
            }
        }
