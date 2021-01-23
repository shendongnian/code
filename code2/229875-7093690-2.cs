    context.
    Items.
    Select(item => new 
                   {
                       Id = i.Id,
                       Name = i.Name,
                       Description = item.
                                     ItemInfo.
                                     Single(info => info.Language == YourGlobalLang).
                                     Description
                   };
