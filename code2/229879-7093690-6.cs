    context.
    Items.
    Select(item => new 
                   {
                       Id = item.Id,
                       Name = item.Name,
                       Description = item.
                                     ItemInfo.
                                     Single(info => info.Language == YourGlobalLang).
                                     Description
                   };
