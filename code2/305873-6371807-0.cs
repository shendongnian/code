        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        
        namespace ConsoleApplication3
        {
            class Seller
            {
                public string Name { get; set; }
                public string TypeOfSeller { get; set; }
            }
        
            class SomeOtherData
            {
                public string Name { get; set; }
            }
        
            static class Program
            {
        
        
                static void Main(string[] args)
                {
                    List<Seller> sellers = new List<Seller>();
                    sellers.Add(new Seller() { Name = "A", TypeOfSeller = "Test" });
                    sellers.Add(new Seller() { Name = "B", TypeOfSeller = "Test" });
                    sellers.Add(new Seller() { Name = "C", TypeOfSeller = "Other" });
        
                    var q = from p in sellers.AsQueryable<Seller>().GetAllByType("Test") select p;
        
                    List<SomeOtherData> other = new List<SomeOtherData>();
                    other.Add(new SomeOtherData() { Name = "A" });
                    other.Add(new SomeOtherData() { Name = "B" });
                    other.Add(new SomeOtherData() { Name = "C" });
        
                    var q2 = from p in other.AsQueryable<SomeOtherData>().GetAllByType("Test") select p;
        
                    foreach (var x in q)
                        Console.WriteLine(x.Name + ", " + x.TypeOfSeller);
        
                    Console.WriteLine("Other Data: ");
        
                    foreach (var x in q2)
                        Console.WriteLine(x.Name);
        
        
                    Console.ReadLine();
                }
        
                public static IQueryable<T> GetAllByType<T>(
            this IQueryable<T> customQuery, string seller) where T : class, new()
                {
                    var prop = typeof(T).GetProperty("TypeOfSeller");
                    if(prop != null)
                    {
    customQuery = customQuery.Where(i => prop.GetValue(i, new object[] {}).ToString() == seller);                }
                    return customQuery;
                }
            }
        }
