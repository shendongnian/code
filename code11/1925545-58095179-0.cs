    public async Task GetCustomData(string user, Root data)
    {
    
        var sub_val2 = data.test1.sub[0].val2.ToString();
    
        //code logic here
    
    
        await Clients.All.SendAsync("ReceiveMessage", user, sub_val2);
    }
