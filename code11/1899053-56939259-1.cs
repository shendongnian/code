    List<ContractTableRow> rows =
           db.Contracts
             .OrderBy( r => r.Id )
             .Skip(page * size)
             .Take(size)
             .Select( c => new ContractTableRow
               {
                  c.Id,
                  c.Worker.Name...
               })
             .ToList();
