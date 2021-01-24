     public static void ConvertTheFloats()
     {
         var dic = File.ReadAllLines("ConvertFloatsData.txt")
             .Select(l => l.Split(new[] { '=' }))
             .ToDictionary(s => s[0].Trim(), s => s[1].Trim());
         var keys = dic.Keys;
         foreach (var key in keys)
         {
             string x = dic[key];
             if (float.TryParse(x, out var floatX))
             {
                 Debug.WriteLine($"Success: Key: {key} - String Value: {x} - Float Value: {floatX}");
             }
             else
             {
                 Debug.WriteLine($"Failed: Key: {key} - String Value: {x}");
             }
         }
     }
