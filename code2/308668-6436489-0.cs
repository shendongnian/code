    var today = DateTime.Today;
    return View(db.Things
        .Where(t => t.DateTimeObj.Date == today)
        .OrderByDescending(e => e.DateTimeObj)
        .Take(num)
    );
    
    //Last 24 hours records:
    var yesterday = DateTime.Now.AddDays(-1);
    return View(db.Things
        .Where(t => t.DateTimeObj > yesterday)
        .OrderByDescending(e => e.DateTimeObj)
        .Take(num)
    );
