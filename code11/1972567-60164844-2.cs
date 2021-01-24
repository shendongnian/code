    var updates = new List<Update>
    {
        new UpdateA
        {
            UpdatedAt=DateTime.Now.AddDays(-1),
            PropertyA = "A"
        },
        new UpdateB
        {
            UpdatedAt=DateTime.Now.AddDays(-1),
            PropertyB = "B"
        }
    };
    
    await Clients.All.SendAsync("ReceiveUpdate", updates);
