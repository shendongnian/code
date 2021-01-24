.Select(line => line.Split(',').Select(s => s.Trim()).ToList())
# Following the instructions
> how do you sort them by EndDate and get the nth value only for each group, not the certain date value?
Here is version that follows the procedure outlined in the question.
var data = @"FilmMaker,   MovieTitle,      EndDate
    FunnyM,      F1,              20191210
    FunnyM,      F2,              20191211
    FunnyM,      F3,              20191212
    FunnyM,      F4,              20191213
    FunnyM,      F5,              20191214
    SadM,        S1,              20191210
    SadM,        S2,              20191211
    SadM,        S3,              20191212
    SadM,        S4,              20191213
    SadM,        S5,              20191214
    ScaryM,      C1,              20191210
    ScaryM,      C2,              20191211
    ScaryM,      C3,              20191212
    ScaryM,      C4,              20191213
    ScaryM,      C5,              20191214";
var d = data.Split("\r\n")
    .Skip(1)
    .Select(line => line.Split(',').Select(s => s.Trim()).ToList())
    .Select( a => new { FilmMaker = a[0], MovieTitle = a[1], EndDate= DateTime.ParseExact(a[2], "yyyyMMdd", CultureInfo.InvariantCulture)}) // No error handling for brevity
    // We have crossed the csv/object boundary
    // 1) group them by FilmMaker 
    .GroupBy( o => o.FilmMaker )       
    // 2) sort them by EndDate
    // 3) select movies that ends after 2019-12-10
    // 4) select only that ends the second earliest
    // NOTE: This is quite fragile - if there is no 2nd earliest movie this will throw
    .Select( g => new { FilmMaker = g.Key, Movie = g.Where( m => m.EndDate > new DateTime(2019,12,10)).OrderBy( m => m.EndDate).Skip(1).First() })
    // 5) make a dictionary that has keys as MovieTitle and also has other two columns as values. 
    .ToDictionary( m => m.Movie.MovieTitle,
                   m => new { FilmMaker = m.FilmMaker, EndDate = m.Movie.EndDate.ToString("yyyyMMdd")});
    
    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(d));
{
"F3":{"FilmMaker":"FunnyM","EndDate":"20191212"},
"S3":{"FilmMaker":"SadM","EndDate":"20191212"},
"C3":{"FilmMaker":"ScaryM","EndDate":"20191212"}
}
