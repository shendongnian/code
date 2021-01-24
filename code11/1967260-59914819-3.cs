    public class Whatever
    {
        private readonly IClassProvider _classProvider;
    
        public Whatever(IClassProvider classProvider)
        {
            _classProvider = classProvider;
        }
    
        public InsertMutationResponse UpsertMethod<TInput>(
        TInput input,
        RequestInput requestInputs)
        {
            var ok = false;
            var errors = new List<string>();
            var requestId = default(Guid);
    
            if (requestInputs != null)
            {
                var @class = classProvider.Get<TInput>();
    
                var masterSection = _dbContext.MasterSections.SingleOrDefault(
                    ms => ms.Name == requestInputs.MasterSection);                
                    requestId = @class.UpsertRequest(
                        input,
                        masterSection,
                        requestInputs,
                        _dbContext);
                    ok = true;           
            }
            return new InsertMutationResponse(ok, errors, requestId);
        }
    }
    public interface IClassProvider
    {
        Class<TInput> Get<TInput>();
    }
    public class ClassProvider
    {
        public Class<TInput> Get<TInput>()
        {
            // return correct Class<TInput> instance based on generic type parameter
        }
    }
    public interface ILibrary
    {
        int Id { get; }
    }
    public abstract class Class<TInput>
       where TLibrary : ILibrary
    {
        protected abstract ILibrary CreateLibrary(TInput input, MasterSection masterSection);
    
        public Guid UpsertRequest(
          TInput input,
          MasterSection masterSection,
          RequestInput requestInputs,
          APIDbContext dbContext)
        {
            Guid id = Guid.NewGuid();
    
            var library = CreateLibrary(input, masterSection);
    
            dbContext.Set<TLibrary>().Add(library);
            dbContext.SaveChanges();
    
            var request = RequestHelper.CreateRequest(masterSection, library.Id, requestInputs, dbContext);
            dbContext.Requests.Add(request);
            dbContext.SaveChanges();
            return request.Id;
        }
    }
    public class ClassA : Class<InputA>
    {
        protected override ILibrary CreateLibrary(InputA input, MasterSection masterSection)
        {
            new LibraryA
            {
                Id = id,
                InitialRevisionId = input.InitialRevisionId ?? id,
                MasterSection = masterSection,
                DirectExhaust = input.DirectExhaust,
                Revision = 0
            };
        }
    }
    
    public class ClassB : Class<InputB>
    {
        protected override ILibrary CreateLibrary(InputB input, MasterSection masterSection)
        {
            return new LibraryB
            {
                Id = id,
                InitialRevisionId = input.InitialRevisionId ?? id,
                MasterSection = masterSection,
                AirClass = input.AirClass,
                Revision = 0
            };
        }
    }
