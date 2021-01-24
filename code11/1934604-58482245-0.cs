public string[] GetMatrixFromString(string seq)
{           
     seq = seq.Replace("Zeile", "");
     var array = seq.Split(';');
     if(array.Length > 0)
     {
          string[] matrix = new string[array.Length];
          for (int i = 0; i < array.Length; i++)
          {
               var item = array[i];
               var matrixLine = item.Split(':')[1].Replace(",", " ");
               matrix[i] = matrixLine;
          }
          return matrix;
      }
      else
      {
          return null;
      }          
}
Be careful to check if return value is null, so that in this case it was not able to parse the string and create matrix.
For example:
string seq3 = "Zeile1: 2,5,4,2; Zeile2: 4,1,7,8; Zeile3: 5,3,6,1; Zeile4: 9,2,3,5";
var matrix = GetMatrixFromString(seq3);
if(matrix == null)
{
      Console.WriteLine("Unable to parse input");
}
else
{
      foreach (var line in matrix)
      {
            Console.WriteLine(line);
      }
} 
