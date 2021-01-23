    context.
    Items.
    Select(item => new 
                   {
                       Id = item.Id,
                       Name = item.Name,
                       Description = item.
                                     ItemInfo.
                                     Where(info => info.Language == YourGlobalLang).
                                     Select(info => info.Description).
                                     FirstOrDefault()
                   };
