    var query = _context.Submodules.Where(t => t.Id == id)
                        .Select(e => new Submodules{
                            Id = e.Id,
                            Name = e.Name,
                            Status = e.Status,
                            Token = e.Token,
                            ModuleId = e.ModuleId,
                            Gender = e.Gender,
                            TotalRows = e.TotalRows,
                            TotalWords = e.TotalWords,
                            CompletedWords = e.Segments.Where(a => a.Status == Abr.Recorded).Sum(y=> y.Wordcount),
                            CompletedRows = e.Segments.Where(a => a.Status == Abr.Recorded).Count()
                        }).ToList();
