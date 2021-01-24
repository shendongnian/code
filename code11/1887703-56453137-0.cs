     public class AutoMapperConfig
        {
            public static object thisLock = new object();
            public static void Initialize()
            {
                lock (thisLock)
                {
                    AutoMapper.Mapper.Reset();
                    AutoMapper.Mapper.Initialize(cfg => { });
                }
            }
        }
    }
