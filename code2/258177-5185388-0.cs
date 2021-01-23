    var list = _entities.LocalizationGlobalTexts
                  .Where(l => l.Language.Id == _currentlanguage)
                  .Select(l => new {l, l.ForeignProp})
                  .ToList();
    foreach(var item in list)
    {
        Console.WriteLine(item.l.Name + item.ForeignProp.Title);
    }
