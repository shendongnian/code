    data.Tasks.AddRange(
        data.Task.AsEnumerable().Select(t => new Task{
            creator_id   = t.ID,
            start_date   = t.Incident.DateOpened,
            end_date     = t.Incident.DateCLosed,
            product_code = t.Incident.ProductCode
            // so on...
        })
    );
    data.SaveChanges();
