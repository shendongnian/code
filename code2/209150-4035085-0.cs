    foreach (DomainObject obj in result.ResultSet)
                {
                    RoomBlock rmblk = (RoomBlock)obj;
    
                    if (!Hotelnm.Contains(rmblk.HotelName))
                    {
                        Hotelnm.Add(rmblk.HotelName);
                        **//roomBlock.Add(new RoomBlockViewModel(rmblk));**
                    }
    
                }
