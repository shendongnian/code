        IEnumerable<Item> KindWork = c.ListKindWorks
        .Select(y => new Item 
        { 
            Id = y.IdKindWork, 
            Value = y.IdKindWorkNavigation.Title
        })
        IEnumerable<Item> Subject = c.ListSubjects
        .Select(y => new Item
        { 
            Id = y.IdSubject, 
            Value = y.IdSubjectNavigation.Title
        })
