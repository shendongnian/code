    public class Whatever
    {    
        public InsertMutationResponse UpsertMethodA(
        LibraryInputA inputA,
        RequestInput requestInputs)
        {
            var ok = false;
            var errors = new List<string>();
            var requestId = default(Guid);
            if (requestInputs != null)
            {
                 var @class = new ClassA();
                var masterSection = _dbContext.MasterSections.SingleOrDefault(
                    ms => ms.Name == requestInputs.MasterSection);                
                requestId = @class.UpsertRequest(
                    inputA,
                    masterSection,
                    requestInputs,
                    _dbContext);
                ok = true;           
            }
            return new InsertMutationResponse(ok, errors, requestId);
        }
        public InsertMutationResponse UpsertMethodB(
        LibraryInputB inputB,
        RequestInput requestInputs)
        {
            var ok = false;
            var errors = new List<string>();
            var requestId = default(Guid);
            if (requestInputs != null)
            {
                 var @class = new ClassB();
                var masterSection = _dbContext.MasterSections.SingleOrDefault(
                    ms => ms.Name == requestInputs.MasterSection);                
                requestId = @class.UpsertRequest(
                    inputB,
                    masterSection,
                    requestInputs,
                    _dbContext);
                ok = true;           
            }
            return new InsertMutationResponse(ok, errors, requestId);
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
