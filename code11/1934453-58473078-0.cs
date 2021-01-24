    DateTime date = DateTime.Now.Date;
    var menus = list.Select(l => new MenuModel
                {
                    Total = l.Date.Date == date ? l.Total : 0,
                    Location = l.Location,
                });
