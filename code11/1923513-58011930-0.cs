public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Name");
        string name = "FIRSTNAME";
        Console.WriteLine("Lastname");
        string lastname = "LASTNAME";
        int i;
        var nchars = name.ToCharArray();
        var pchars = lastname.ToCharArray();
        var ncharsCount = nchars.Length;
        var pcharsCount = pchars.Length;
        //for (i=0;i<=10;i++){
            int ctr0;
            int ctr;
            int ctr2;
            for (ctr = 0, ctr2 = 1, ctr0=1; ctr0 < 10 ;ctr0++, ctr++,ctr2++){
                Console.WriteLine("{0}{1}{2}{3}{4}", ctr0,nchars[ctr%ncharsCount],nchars[ctr2%ncharsCount],pchars[ctr%pcharsCount],pchars[ctr2%pcharsCount]);
            }
        //}
    }
}
