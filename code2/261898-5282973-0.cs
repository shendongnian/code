    interface MainInterface
    {
        Int ID{get;}
    }
    
    and in Reporsitory  :
    public interface IRepository<TE, TC>  : where TE is MainInterface
        {
            void Add(TE entity);
            void AddOrAttach(TE entity);
            void DeleteRelatedEntries(TE entity);
            void DeleteRelatedEntries(TE entity, ObservableCollection<string> keyListOfIgnoreEntites);
            void Delete(TE entity);
            int Save();
    
            //this is where I am stuck
            TE GetById();
    
        }
