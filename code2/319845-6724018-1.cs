    var ctx = Context;
    var contractToDelete = ctx.Contracts.Where(c => c.ContractId == 1).First();
    contractToDelete.ByUser = username;
    ctx.Contracts.ApplyOriginalValues(contractToDelete);
    ctx.DeleteObject(contractToDelete);
    ctx.SaveChanges();
