        public struct ProcessorCreationSettings
        {
            public Predicate<Request> Predicate;
            public Func<Request, IProcessor> Creator;
        }
        public class ProcessorFactory
        {
            protected static List<ProcessorCreationSettings> settings = new List<ProcessorCreationSettings>();
            static ProcessorFactory()
            {
                settings.Add(new ProcessorCreationSettings
                {
                    Predicate = r => r.Type == RequestType.SomeOther && r.Id > 1000,
                    Creator = r => new ProcessLargeRequest(r)
                });
                settings.Add(new ProcessorCreationSettings
                {
                    Predicate = r => r.Type == RequestType.SomeOther && r.Id <= 1000,
                    Creator = r => new ProcessSmallRequest(r)
                });
            }
            public List<IProcessor> Create(Request request)
            {
                return settings
                    .Where(s => s.Predicate(request))
                    .Select(s => s.Creator(request))
                    .ToList();
            }
        }
