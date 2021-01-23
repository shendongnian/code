    //I can't remember the exact syntax but it is very similar to this
    public class MyEntity
    {
    
    [NHibernateValidation(Length(min=1, max=10)]
    public String Name {get;set;}
    
    }
    
    //... and then later ...
    NHibernateValidator.Validate(myEntity);
