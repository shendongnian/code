    table.Where(w=>w.Id==result.Id && !result.IsDeleted && w.CreationDate==result.CreationDate)
    .Select(s => new Log {Url="testing update" }).Update().Execute();
    
    table.Where(w=>w.Id==result.Id && !result.IsDeleted && w.CreationDate==result.CreationDate)
    .Select(s => new {Url="testing update" }).Update().Execute();
