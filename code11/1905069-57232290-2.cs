    // Minimal reasonable set of attributes
    interface IPerson 
    {
       id
       name
       lastname
       country
    }
    
    // This interface extends IPerson
    interface IPersonDetails : IPerson 
    {
       dni
       childs
       pets
       ...   
    }
    
    // Maybe add some database related attributes like primaryKey
    interfcae IPersonEntity : IPerson, IPersonDetails 
    {
    }
    
    
    // A PersonModel is an implementation of all role interfaces
    class PersonModel : IPersonEntity 
    {
    }
    
