    //Every object in the domain has an identity-sourced Id field
    public interface IDomainObject
    {
       long Id{get;}
    }
    
    //No additional useful information other than this is an object from the user security DB
    public interface ISecurityDomainObject:IDomainObject {}
    
    //No additional useful information other than this is an object from the Northwind DB
    public interface INorthwindDomainObject:IDomainObject {}
    
    
    //No additional useful information other than this is an object from the Southwind DB
    public interface ISouthwindDomainObject:IDomainObject {}
