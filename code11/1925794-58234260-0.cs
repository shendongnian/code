c#
using (var context = new BlogContext())
{
    context.Database.Log = Console.Write; // set Database.Log property inside dbContex constructor to log all queries
    //your query here
}
this will output every query with parameters passed and **time it took to execute the query.**
