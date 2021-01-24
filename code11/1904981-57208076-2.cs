    public List<SelectListItem> WarehouseFilterSelectItems { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string WarehouseFilter { get; set; }
    WarehouseFilterSelectItems = _context.Warehouse
                                         .Select(a => new SelectListItem
                                         {
                                             Value = a.ID.ToString(),
                                             Text = a.WarehouseName
                                         }).ToList();
