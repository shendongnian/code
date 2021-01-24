public static void Main(string[] args)
{
  var d = new Dictionary<string,(string CaseSensitiveKey,SO Data)>() {
    { "Gerardo Grignoli".ToLower(), ("Gerardo Grignoli", new SO { Number=97471, Rep=7987} )},
    { "John Wu".ToLower(), ("John Wu", new SO { Number=2791540, Rep=34973})}
  };
  foreach( var searchTerm in new []{ "Gerardo Grignoli",  "Gerardo Grignoli".ToLower()} )
  foreach( var isSearchCaseSensitive in new[]{true,false} ) {
      Console.WriteLine($"{searchTerm}/case-sensitive:{isSearchCaseSensitive}: {Search(d, searchTerm, isSearchCaseSensitive)?.Rep}");
  }
}
public static SO Search(Dictionary<string,(string CaseSensitiveKey,SO Data)> d, string searchTerm, bool isSearchCaseSensitive )
  => d.TryGetValue(searchTerm.ToLower(), out var item)
          ? !isSearchCaseSensitive 
                ? item.Data
                : searchTerm == item.CaseSensitiveKey ? item.Data : null
          : null;
Output 
Gerardo Grignoli/case-sensitive:True: 7987
Gerardo Grignoli/case-sensitive:False: 7987
gerardo grignoli/case-sensitive:True: 
gerardo grignoli/case-sensitive:False: 7987
