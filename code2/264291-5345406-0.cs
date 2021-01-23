    [Test]
    public void Can_Expire()
    {
    	Redis.SetEntry("key", "val");
    	Redis.Expire("key", 1);
    	Assert.That(Redis.ContainsKey("key"), Is.True);
    	Thread.Sleep(2000);
    	Assert.That(Redis.ContainsKey("key"), Is.False);
    }
    
    [Test]
    public void Can_ExpireAt()
    {
    	Redis.SetEntry("key", "val");
    
    	var unixNow = DateTime.Now.ToUnixTime();
    	var in1Sec = unixNow + 1;
    
    	Redis.ExpireAt("key", in1Sec);
    
    	Assert.That(Redis.ContainsKey("key"), Is.True);
    	Thread.Sleep(2000);
    	Assert.That(Redis.ContainsKey("key"), Is.False);
    }
