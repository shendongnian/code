    var settingViewModels = from l in settingsByEnvironment["Localhost"].AsQueryable()
                            from d in settingsByEnvironment["Dev"].AsQueryable()
                            from p in settingsByEnvironment["Prod"].AsQueryable()
                            where l.Key == d.Key && p.Key == d.Key
                            select new MyKeyValue
                            {
                                Key = p.Key,
                                LocalhostValue = l.Value,
                                DevValue = d.Value,
                                ProdValue = p.Value
                            };
    var expression = settingsViewModels.Expression;
