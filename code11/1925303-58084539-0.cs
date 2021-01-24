    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication132
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable tableSomeWords = new DataTable();
                tableSomeWords.Columns.Add("id", typeof(int));
                tableSomeWords.Columns.Add("code", typeof(string));
                tableSomeWords.Columns.Add("lineNr", typeof(int));
                tableSomeWords.Columns.Add("words", typeof(string));
                tableSomeWords.Rows.Add(new object[] { 1, "C001", 1, "Foo" });
                tableSomeWords.Rows.Add(new object[] { 2, "C001", 2, "Bar" });
                tableSomeWords.Rows.Add(new object[] { 3, "C002", 1, "Hello" });
                tableSomeWords.Rows.Add(new object[] { 4, "C002", 2, "Big Blue" });
                tableSomeWords.Rows.Add(new object[] { 5, "C002", 3, "World" });
                DataTable somePerson = new DataTable();
                somePerson.Columns.Add("id", typeof(int));
                somePerson.Columns.Add("code", typeof(string));
                somePerson.Columns.Add("name", typeof(string));
                somePerson.Rows.Add(new object[] { 1, "C002", "John"});
                somePerson.Rows.Add(new object[] { 2, "C001", "Sam" });
                var results = (from person in somePerson.AsEnumerable()
                               join words in tableSomeWords.AsEnumerable() on person.Field<string>("code") equals words.Field<string>("code")
                               select new { words = words, person = person })
                               .GroupBy(x => x.person.Field<string>("code"))
                               .ToList();
                DataTable tableCombineWords = new DataTable();
                tableCombineWords.Columns.Add("id", typeof(int));
                tableCombineWords.Columns.Add("code", typeof(string));
                tableCombineWords.Columns.Add("name", typeof(string));
                tableCombineWords.Columns.Add("words", typeof(string));
                foreach (var result in results)
                {
                    tableCombineWords.Rows.Add(new object[] {
                        result.FirstOrDefault().person.Field<int>("id"),
                        result.FirstOrDefault().person.Field<string>("code"),
                        result.FirstOrDefault().person.Field<string>("name"),
                        string.Join(" ",result.Select(x => x.words.Field<string>("words")))
                    });
                }
            }
        }
    }
