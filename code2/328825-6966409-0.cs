        public struct ProcessorCreationSettings
        {
            public Predicate<Request> Predicate;
            public Func<Request, IProcessor> Creator;
        }
        public class ProcessorFactory<T> where T : Request
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
            public IProcessor Create(Request request)
            {
                var creator = settings.FirstOrDefault(s => s.Predicate(request)).Creator;
                return creator != null ? creator(request) : null;
            }
        }
