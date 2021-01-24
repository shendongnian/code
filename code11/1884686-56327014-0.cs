            List<ModelMMaster> _listMaster = new List<ModelMMaster>();
            List<ModelDetail> _listDetail = new List<ModelDetail>();
            _listDetail.Add(new ModelDetail { SKUCode = "SKUCode-1", Quantity = 1, Price = 1 });
            _listMaster.Add(new ModelMMaster { OrderID = "OrderID-1", IsActive = true, _detail = _listDetail });
            _listDetail = new List<ModelDetail>();
            _listDetail.Add(new ModelDetail { SKUCode = "SKUCode-2", Quantity = 2, Price = 2 });
            _listDetail.Add(new ModelDetail { SKUCode = "SKUCode-3", Quantity = 3, Price = 3 });
            _listMaster.Add(new ModelMMaster { OrderID = "OrderID-2", IsActive = true, _detail = _listDetail });
            var totalSum = _listMaster.Where(t=>t.IsActive).SelectMany(t => t._detail).Sum(t => t.Quantity * t.Price);
