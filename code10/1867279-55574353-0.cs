csharp
public class UserLocal
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int IdLogin { get; set; }
    public string Token { get; set; }             
    public string Nombre { get; set; }
    public string Rut { get; set; }
    public bool Recordado { get; set; }
    public string Password { get; set; }
    // THIS BIT HERE 
    [OneToMany(CascadeOperations = CascadeOperation.All)
    public List<Companie> Companies { get; set; }
}
The other thing is if you are using this library then you can `insertWithChildren` to create the relationship like so:
csharp
var user = new UserLocal
{
    IdLogin = loginResponse.Id,
    Nombre = loginResponse.Name,
    Recordado = Settings.Recordado,
    Rut = loginResponse.Rut,
    Token = loginResponse.Token,
    Password = GetSHA1(Settings.Password),
    Companies = ListaCompanie,
};
// I WALK THE NUMBER OF COMPANIES THAT I WANT TO ADD
foreach (var item in loginResponse.Companies)
{
    var companie = new Companie
    {
        IdLogin = item.Id,
        Nombre = item.Name,
        ExternalCorp = item.ExternalCorp,
        IsCorporate = item.IsCorporate,
        Principal = item.Principal,
        //CLAVE FORANEA
        UserLocal = user,
        // You dont need to set this as it will be assigned in InsertWithChildren
        // IdUser = loginResponse.Id,
    };
    ListaCompanie.Add(companie);
    await dataService.InsertWithChildren(companie);
}
  [1]: https://www.nuget.org/packages/SQLiteNetExtensions/
