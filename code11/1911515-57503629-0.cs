var searchTerm = //user input;
var countSearch = searchTerm.Split().Count(); //splits the search and count how many
var query = tables.AsQueryable();
if (countSearch == 1) // condition will check any
{
    query = query.Where(a => 
                             searchTerm.Contains(a.Color) || 
                             searchTerm.Contains(a.Animal) || 
                             searchTerm.Contains(a.CarBrand))
                 .ToList();
            }
else if (countSearch == 2) //condition will check at least two combinations
{
    query  = query.Where(a => (searchTerm.Contains(a.Color) && searchTerm.Contains(a.Animal)) 
                           || (searchTerm.Contains(a.Color) && searchTerm.Contains(a.CarBrand)) 
                           || (searchTerm.Contains(a.Animal) && searchTerm.Contains(a.CarBrand)))
                  .ToList();
}
else if (countSearch == 3) //combination will check all
{
    query = query.Where(a => 
                             searchTerm.Contains(a.Color) && 
                             searchTerm.Contains(a.Animal) && 
                             searchTerm.Contains(a.CarBrand))
                 .ToList();
}
var results = query.ToList();
