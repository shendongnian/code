    public ActionResult Index(IEnumerable<int> ids)
    {
        var result = ids.AsParallel()
          .Select(id => GetOrder(id))
          .ToList();
        return Json(result);
    }
    Order GetOrder(int id) { ... }
