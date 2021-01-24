    public interface ILibrary
    {
        int Id { get; }
    }
    public abstract class Class<TInput, TLibrary>
       where TLibrary : ILibrary
    {
        protected abstract TLibrary CreateLibrary(TInput input, MasterSection masterSection);
    
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
    public class ClassA : Class<InputA, LibraryA>
    {
        protected override LibraryA CreateLibrary(InputA input, MasterSection masterSection)
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
    
    public class ClassB : Class<InputB, LibraryB>
    {
        protected override LibraryB CreateLibrary(InputB input, MasterSection masterSection)
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
