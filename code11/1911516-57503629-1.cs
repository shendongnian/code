var searchTerm = //user input;
var countSearch = searchTerm.Split().Count(); //splits the search and count how many
var query = tables.AsQueryable();
if (countSearch == 1) // searchTerm will check any rows
{
    query = query.Where(a => 
                             searchTerm.Contains(a.Color) || 
                             searchTerm.Contains(a.Animal) || 
                             searchTerm.Contains(a.CarBrand));
            }
else if (countSearch == 2) //searchTerm will check at least two combinations on rows
{
    query  = query.Where(a => (searchTerm.Contains(a.Color) && searchTerm.Contains(a.Animal)) 
                           || (searchTerm.Contains(a.Color) && searchTerm.Contains(a.CarBrand)) 
                           || (searchTerm.Contains(a.Animal) && searchTerm.Contains(a.CarBrand)));
}
else if (countSearch == 3) //searchTern will check all rows
{
    query = query.Where(a => 
                             searchTerm.Contains(a.Color) && 
                             searchTerm.Contains(a.Animal) && 
                             searchTerm.Contains(a.CarBrand));
}
var results = query.ToList();
