    var items = from e in Person.BusinessEntity
            join p in Person.Person on 
                 e.BusinessEntityID equals p.BusinessEntityID
            join b in Person.BusinessEntityContact on 
                 new {e.BusinessEntityID, p.BusinessEntityID} equals 
                 new { b.BusinessEntityID, b.PersonID} 
            select p;
