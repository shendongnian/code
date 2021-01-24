    var operationsWithActiveSubOps = Db.OperationCodes
         .Include(o => o.SubOperationCode)
         .Select(o => new {
              OperationId = o.Id,
              OperationCode = o.Code,
              ActiveSubOperations = o.SubOperationCode.Where(so => so.Active)
         })
         .ToList();
