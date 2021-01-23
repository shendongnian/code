    var map = new PropertyMap<ProductViewModel>();
    map.Add("Id", p => p.Id);
    map.Add("Code", p => p.Code);
    map.Add("Description", p => p.Description);
    map.Add("Active", p => p.Active);
    var productViewModel = map.CreateObject(values);
