    public class SanitizeFileName
    {
       public static string ReplaceInvalidFileNameChars(string fileName, char? replacement = null)
       {
          if (fileName != null && fileName.Length != 0)
          {
             var sb = new StringBuilder();
             var badChars = new[] { ',', ' ', '^', '°' };
             var inValidChars = Path.GetInvalidFileNameChars().Concat(badChars).ToList();
             foreach (var @char in fileName)
             {
                if (inValidChars.Contains(@char))
                {
                   if (replacement.HasValue)
                   {
                      sb.Append(replacement.Value);
                   }
                   continue;
                }
                sb.Append(@char);
             }
             return sb.ToString();
          }
          return null;
       }
    }
