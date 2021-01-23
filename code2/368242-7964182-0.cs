    for (int i = 0; i < hardCodedData.Count; i++)
    {
        Assert.AreEqual(hardCodedData[i].GameServerId, data[i].Id);
        Assert.AreEqual(hardCodedData[i].GameServerName, data[i].Name);
        ...
    }
