	 private SmartCache GetTester(out Mock<IMemoryCache> memory, out Mock<IRedisCache> redis)
	 {
		 memory = new Mock<IMemoryCache>();
		 redis = new Mock<IRedisCache>();
		 return new SmartCache(memory.Object, redis.Object);
	 }
