 <add name="DBContext1" connectionString=" ... / >
 <add name="DBContext2" connectionString=" ... / >   
second on your contextdb constructor add a parameter for your connection. 
public partial class YourContextDB: DbContext
{
        public YourContextDB(string connection = "name=DBContext1")
            : base(connection )
        {
        }
        ... //basically ur models below
}
3rd
you can now do this. 
string connection = (statement) ? "name=DBContext2" : "name=DBContext1";
YourContextDB dbcontext = new YourContextDB(connection); //default is "name=DBContext1"
Model data =  (from table in dbcontext <--- dynamic dbcontext
               .Model
               where table.ref_no == ref_no
               select new Model
               {
                ...
               });
NOTE: you cannot use code-first `Update-Database` with this solution. 
