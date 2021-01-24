using System;
using System.Text.RegularExpressions;
public class Program
{
	public static void Main()
	{
			var input ="\"1,2-Benzene-d4\",36925,10.483,0.95,,";
			//Define pattern
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            //Separating columns to array
            string[] X = CSVParser.Split(input);
	
			for (int i=0;i<X.Length;i++)
				Console.WriteLine("{0}: {1}\n",i,X[i]);
	}
}
  [1]: https://dotnetfiddle.net/#&togetherjs=V5023jdhfe
