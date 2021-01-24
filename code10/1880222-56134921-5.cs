    List<RecordProduct> list = await context.RecordsProducts
        .Where(i => i.RecordId == model.OldRecordId)
        .ToListAsync();
    foreach( RecordProduct rp in list )
    {
        context.RecordsProduct.Add( ... );
    }
    await context.SaveChangesAsync();
        
