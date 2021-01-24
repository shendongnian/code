    foreach (var prr in item.Psr) //< ---prr
    {
        //in here you have pr
        srArray.Add(new SRItem
        {
            name = pr.Name.lastName + "/" + pr.Name.firstName,
            st= pr.Seat.seatNumber,
            sr = pr.PSRList[0].SRCode                                
        });
    }
