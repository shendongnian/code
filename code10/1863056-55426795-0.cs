    var query2 = 
        from t in db.Tour
        join tc in db.TourCategory on t.ID equals tc.TourID
        where tc.CategoryID == 3
        // join dates aggregates grouped by tour id
        join tdates in
            from td in db.TourDates on t2.ID
            join d in db.Dates on td.DatesID equals d.ID
            group d by td.TourID into grp
            select new 
            { 
                tourID = grp.Key, 
                departure = grp.Max(g => g.DepartureDateRange), 
                rtrn = grp.Max(g => g.ReturnDateRange)
            }
        on t.ID equals tdates.tourID
        select new IndexTour
        {
            ID = t.ID,
            TourName = t.TourName,
            DepartureDateRange = tdates.departure,
            ReturnDateRange = tdates.rtrn,
            Description = t.SmallDesc,
            Price = t.Price,
            CoverPhotoUrl = t.CoverPhotoUrl,
            TourProgram = t.TourDesc
        };
