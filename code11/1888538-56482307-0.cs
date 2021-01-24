    public override OperationCode getById(Guid id)
    {
        return Db.OperationCode.Include(o => o.SubOperationCode)
            .FirstOrDefault(o => o.Id == id && o.SubOperationCode.Any(so => so.Active))
    }
