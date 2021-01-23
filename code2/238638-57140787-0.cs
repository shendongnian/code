        public void ReadExcelUsingExcelMapperExtension()
        {
            string filePath = @"C:\Temp\ListOfPeople.xlsx";
            var people = new ExcelMapper(filePath).Fetch<Person>().ToList();
        }
        public class Person
        {
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public int Age { get; set; }
        }
