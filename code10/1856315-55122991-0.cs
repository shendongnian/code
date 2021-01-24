    public static IQueryable<MroomLinqModel> GetDefaultQuery(CustomerContext CustomerCtx, bool? roomHidden, DateTime? dtLoadEnd 
     /* you can add more parameters but for demonstrations purposes i'm only describing this 2*/)
    {
            var query = CustomerCtx.Mrooms;
            if(roomHidden.HasValue)
            {
               query = query.Where( q=>q.From == roomHidden.Value)
            }
    
            if(dtLoadEnd  .HasValue)
            {
               query = query.Where( q=>q.RoomHidden <= dtLoadEnd.Value)
            }
            // you can add more conditions 
            
            var Mrooms = (from query 
                          join m in CustomerCtx.Moves on mr.MoveId equals m.MoveId
                          join mg in CustomerCtx.mgroup on m.MgroupId equals mg.MgroupId
                          join s in CustomerCtx.Status on m.StatusId equals s.StatusId
                          join rt in CustomerCtx.Roomtypes on mr.RoomtypeId equals rt.Key
                          join g in CustomerCtx.Guests on m.Mgroup.GuestId equals g.GuestId
    
                          where
                          Math.Abs(mg.Status) != (int)IResStatus.InComplete &&
                          s.Visible
    
                          select new MroomLinqModel
                          {
                              OpenDepositPayments = mg.DepositPayments.Any(dp => !dp.Paid),
                              RoomHidden = (mr.RoomId == null ? true : mr.Room.Hidden),
                              StatusVisible = s.Visible,
    
                              MroomId = mr.MroomId,
                              MoveId = m.MoveId,
                              MgroupId = mg.MgroupId,
                              StatusId = s.StatusId,
                              StatusFlags = s.Flags,
                              BackgroundColor = s.Background_Argb,
                              TextColor = s.Foreground_Argb,
                              PersonCount = m.Movegroups.Sum(m => m.PersonCount),
                              MoveCount = mg.Moves.Count(),
    
                              RoomId = mr.RoomId,
                              PMSMroomId = mr.PMS_Id,
                              PMSMoveId = m.PMS_Id,
                              PMSMgroupId = mg.MgroupId_Casablanca,
    
                              From = mr.From,
                              Until = mr.Until,
    
                              EditableState = m.EditableState,
                              MroomStatus = mr.Status,
                              RoomtypeUsage = mr.Roomtype.Usage,
    
                              BookingReference = mg.ReferenceNumber,
    
                              Guest = g
                          });
    
            return Mrooms;
    }
