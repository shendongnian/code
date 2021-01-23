    //identifies a class as persistable, and requires the class to specify 
    //an identity column for its PK
    public interface IDomainObject { long Id {get;} } 
    //In a repository-per-DB model, just because it's an IDomainObject doesn't mean
    //a repo can work with it. So, I derive further to create basically "marker"
    //interfaces identifying domain objects as being from a particular DB:
    public interface ISecurityDomainObject:IDomainObject { }
    public interface IDataDomainObject:IDomainObject { }
    public interface IData2DomainObject:IDomainObject { }
    //There may be logic in your repo or DB to prevent certain concurrency issues.
    //You can specify that a domain object has the necessary fields for version-checking
    //either up at the IDomainObject level, a lower level, or independently:
    public interface IVersionedDomainObject:IDomainObject
    { 
       long Version {get;}
       string LastUpdatedBy {get;}
       DateTime LastUpdatedDate {get;}
    }
    //Now, you can use these interfaces to restrict a Repo to a particular subset of
    //the full domain, based on the DB each object is persisted to:
    public interface IRepository<TDom> where TDom:IDomainObject 
    {
        //yes, GTPs can be used as GTCs
        T GetById<T>(long Id) where T:TDom;
        void Save<T>(T obj) where T:TDom;
        //not only must the domain class for SaveVersioned() implement TRest,
        //it must be versionable
        void SaveVersioned<T>(T versionedObj) where T:TDom, IVersionedDomainObject
    }
    
    //and now you can close TDom to an interface which restricts the concrete
    //classes that can be passed to the generic methods of the repo:
    public class ISecurityRepo:IRepository<ISecurityDomainObject> { ... }
