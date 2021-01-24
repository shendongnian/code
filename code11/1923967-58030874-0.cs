    var list = _context.Tool
        .Join(_context.Entry, 
              o => o.ToolId, 
              od => od.FktoolId, 
              (o, od) => new { od.Measure, od.V, od.RunDate, od.User, o.Name })
        .ToList();
    ViewBag.Testing = JsonConvert.SerializeObject(list);
