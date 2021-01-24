    /// <summary>
    /// Attaches a memory appender
    /// </summary>
    /// <param name="log"></param>
    public static MemoryAppender AttachMemoryAppender(this ILog log)
    {
    	var memoryAppender = new log4net.Appender.MemoryAppender
    	{
    		//	*** AppenderSkeleton ***
    		Name = log.GetLogger().Name,
    		Threshold = log.GetLogger().Repository.LevelMap["DEBUG"],
    
    		//	*** MemoryAppender ***
    		Fix = FixFlags.All
    	};
    	
    	var layout = new log4net.Layout.PatternLayout
    	{
    		ConversionPattern = "%date - %-5level - %message%newline"
    	};
    
    	layout.ActivateOptions();
    	memoryAppender.Layout = layout;
    	memoryAppender.ActivateOptions();
    
    	log.GetLogger().AddAppender(memoryAppender);
    
    	return memoryAppender;
    }
