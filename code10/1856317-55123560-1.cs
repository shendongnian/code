    public static IQueryable<MroomLinqModel> GetDefaultQuery(CustomerContext CustomerCtx, Expression<Function<Mroom, bool>> q)
    {
        Expression<Function<Mroom, bool>> w = PredicateBuilder.New<Mroom>
           (s => Math.Abs(s.Mgroup.Status) != (int)IResStatus.InComplete &&
           s.Visible);
        w = w.And(q);
        return 
            CustomerCtx.Mrooms.
            Where(w.Expand()).
            Select( x => new MroomLinqModel
            {
                OpenDepositPayments = x.Mgroup.DepositPayments.Any(dp => !dp.Paid),
                RoomHidden = (x.RoomId == null ? true : x.Room.Hidden),
                StatusVisible = x.Status.Visible,
                MroomId = x.MroomId,
                MoveId = x.MoveId,
                MgroupId = x.MgroupId,
                StatusId = x.Status.StatusId,
                StatusFlags = x.Status.Flags,
                BackgroundColor = x.Status.Background_Argb,
                TextColor = x.Status.Foreground_Argb,
                PersonCount = x.Move.Movegroups.Sum(m => m.PersonCount),
                MoveCount = x.Mgroup.Moves.Count(),
                RoomId = x.RoomId,
                PMSMroomId = x.PMS_Id,
                PMSMoveId = x.Move.PMS_Id,
                PMSMgroupId = x.Mgroup.MgroupId_Casablanca,
                From = x.From,
                Until = x.Until,
                EditableState = x.Move.EditableState,
                MroomStatus = x.Move.Status,
                RoomtypeUsage = mr.Roomtype.Usage,
                BookingReference = x.Mgroup.ReferenceNumber,
                Guest = x.Guest
            }
        );
    }
