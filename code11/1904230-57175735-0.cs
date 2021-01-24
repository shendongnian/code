c#
using System.Collections.Generic;
using System.Linq;
namespace FindAStringInAListOfStringsWithReflection
{
    class someType
    {
        public string CategoryType { get; set; }
        public string Product { get; set; }
        public string ValueType { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> typesList = new List<string>();
            typesList.Add("product");
            typesList.Add("valuetype");
            typesList.Add("categorytype");
            foreach (var prop in typeof(someType).GetProperties())
            {
                bool wtf1 = typesList.Any(x => x == prop.Name.ToLower());
                bool wtf2 = typesList.Contains(prop.Name.ToLower());
                var wtf3 = typesList.Where(x => x == prop.Name.ToLower()).FirstOrDefault();
                bool wtf4 = string.IsNullOrEmpty(typesList.Where(x => x == prop.Name.ToLower()).FirstOrDefault());
                bool wtf5 = !string.IsNullOrEmpty(typesList.Where(x => x == prop.Name.ToLower()).FirstOrDefault());
                bool wtf6 = typesList.Any(s => s.Contains(prop.Name.ToLower()));
                //Debugging breakpoint on next line...
                bool pause = true;
            }
        }
    }
}
