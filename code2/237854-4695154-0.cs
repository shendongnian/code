    parcels
            .Where(p => !p.Owners.IsNullOrEmpty())
            .SelectMany(p => p.Owners.Select(o => new { Parcel = p, Owner = o }))
            .OrderByDescending(x => x.Owner.RecordingDate ?? x.Owner.SaleDate ?? x.Owner.DateEntered)
            .ForEach(item =>
            {
                Parcel p = item.Parcel;
                Owner o = item.Owner;
                ...
            }
