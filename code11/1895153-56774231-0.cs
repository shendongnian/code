    using Microsoft.Extensions.DependencyInjection;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddTransient(typeof(IDataMapper<,>), typeof(DataMapper<,>));
                serviceCollection.AddTransient<EventService>();
                serviceCollection.AddTransient<RegionService>();
                var provider = serviceCollection.BuildServiceProvider();
                var eventService = provider.GetRequiredService<EventService>();
                var regionService = provider.GetRequiredService<RegionService>();
            }
        }
        class EventService
        {
            public EventService(IDataMapper<EventData, EventEntity> mapper)
            {
                mapper.Map(new EventData(), new EventEntity());
            }
        }
        class RegionService
        {
            public RegionService(IDataMapper<RegionData, RegionEntity> mapper)
            {
                mapper.Map(new RegionData(), new RegionEntity());
            }
        }
        public interface IData { }
        public interface IEntity { }
        public interface IDataMapper<T, K> where T : IData where K : IEntity
        {
            void Map(T data, K entity);
        }
        public class EventData : IData { }
        public class RegionData : IData { }
        public class EventEntity : IEntity { }
        public class RegionEntity : IEntity { }
        public class DataMapper<T, K> : IDataMapper<T, K> where T : IData where K : IEntity
        {
            public void Map(T data, K entity)
            {
                if (data is EventData eData && entity is EventEntity eEntity)
                {
                    // map event
                }
                else if (data is RegionData rData && entity is RegionEntity rEntity)
                {
                    // map region
                }
            }
        }
    }
