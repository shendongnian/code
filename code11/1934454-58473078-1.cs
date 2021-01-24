    DateTime date = DateTime.Today;
    var menus = list.Select(l => new MenuModel
                {
                    Total = l.Date.Date == date ? l.Total : 0,
                    Location = l.Location,
                });
