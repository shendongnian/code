        telCollection = new List<IEnumerable<TransactionEntity>>();
        telCollection = telCollection.Concat(new[] { tel1 });
        telCollection = telCollection.Concat(new[] { tel2 });
        telCollection = telCollection.Concat(new[] { tel3 });
        ViewData.Model = telCollection;
        return View();
