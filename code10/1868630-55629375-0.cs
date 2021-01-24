    public static void Main(string[] args)
    {
        // create new object of Show type
        Show s = new Show(153, 258, 391);
        Movie movieA = new Movie();
        // add object to List
        movieA.Shows.Add(s);
        // The output gives me 153, which is correct
        Console.WriteLine(movieA.Shows.ElementAt(0).ShowID);
        var access = new Access();
        access.MyMethod(movieA);
    }
    public class Access
    {
       public void MyMethod(Movie movie)
       {
           // this should work
           Console.WriteLine(movie.Shows.ElementAt(0).ShowID);
       }
    }
