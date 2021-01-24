    using System.Collections.Generic;
    public class Program
    {
      public class PlayerInformation
      {
        public string RoleName { get; set; }
        public int RoleR { get; set; }
        public int RoleG { get; set; }
        public int RoleB { get; set; }
        public int Cash { get; set; }
        public int Bank { get; set; }
      }
      public class Licenses : Dictionary<string, PlayerInformation>
      {
      }
      static void Main(string[] args)
      {
        var licenses = new Lisences();
        licenses.Add("AAAAAAAAA",
                     new PlayerInformation
                     {
                       RoleName = "PLayer",
                       RoleR = 255,
                       RoleG = 255,
                       RoleB = 255,
                       Cash = 12,
                       Bank = 1452
                     });
        licenses.Add("BBBBBBBBB",
                     new PlayerInformation
                     {
                       RoleName = "PLayer",
                       RoleR = 255,
                       RoleG = 255,
                       RoleB = 255,
                       Cash = 12,
                       Bank = 1452
                     });
        foreach ( var item in licenses )
          Console.WriteLine(item.Key + ": " + item.Value.RoleName + ", " + item.Value.Bank);
        Console.ReadKey();
      }
    }
