    foreach (var pr in item.Psr)
    {
        srArray.Add(new SRItem
        {
            name = pr.Name.lastName + "/" + pr.Name.firstName,
            st= pr.Seat.seatNumber,
            sr = pr.PSRList[0].SRCode                                
        });
    }
