    public class Company
    {
        public string Name { get; private set; }        
        public ISet<Debtor> Debtors { get; private set; }
        public ISet<Creditor> Creditors { get; private set; }
        public ISet<Lead> Leads { get; private set; }
        ...
    }
    
    
    public class CompanyRole
    {
        public Company innerCompany { get; set; }
        //Override to allow equality of the same company across Roles
        public override bool Equals(object other) 
        {
           if(other is Company) 
              return ((Company) other).Name.Equals(innerCompany.Name);
           else if(other is CompanyRole) 
              return ((CompanyRole) other).innerCompany.Name.Equals(innerCompany.Name);
           else 
              return false;
        }
        public override int HashCode() 
        {
           return innerCompany.Name.HashCode();
        }
        ....
    }
    
    public class Debtor: CompanyRole 
    {
        ....
    }
    
    public class Creditor: CompanyRole  
    {
        ....
    }
    
    public class Lead: CompanyRole  
    {
        ....
    }
