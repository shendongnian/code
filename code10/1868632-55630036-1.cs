public class Access
{
    public void ShowMovieOutput(Movie mov)
    {
        Console.WriteLine(mov.Shows.ElementAt(0).ShowID);
    }
}
public static void Main(string[] args)
{
    // create new object of Show type
    Show s = new Show(153, 258, 391);
    Movie mv = new Movie();
    // add object to List
    mv.Shows.Add(s);
    Access.ShowMovieOutput(mv);
    // The output gives me 153, which is correct
    Console.WriteLine(mv.Shows.ElementAt(0).ShowID);
}
