    Task loadTask = context.RecordsProducts
            .Where(i => i.RecordId == model.OldRecordId)
            .ForEachAsync(a =>
            {
                var newRecordProduct = new RecordProduct
                {
                    IsActive = true,
                    RecordId = model.RecordId,
                    ProductId = a.ProductId,
                    DefendantId = a.DefendantId,
                    Annotation = a.Annotation
                };
                context.RecordsProducts.Add(newRecordProduct);
            }
        );
    await loadTask; // This will wait (actually, _yield_) until all of the `ForEachAsync` iterations are complete.
    await context.SaveChangesAsync(); // This will actually save the new rows added to `context.RecordsProducts`
