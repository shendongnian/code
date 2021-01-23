    [HttpPost]
    public virtual ActionResult Create(IEnumerable<OrderItem> orderItems)
        {
            if (orderItems.Count() == 0)
            {
                return RedirectToAction("NoOrderItems");
            }
            else
            {
                TempData["orderItems"] = orderItems;
                return RedirectToAction("Confirm");
            }
        }
        [HttpGet]
        public virtual ActionResult Confirm()
        {
            var orderItems = TempData["orderItems"] as IEnumerable<OrderItem>;
            if (orderItems == null || orderItems.Count() == 0)
            {
                this.InvokeHttp404(ControllerContext.HttpContext);
            }
            return View(orderItems);
        }
