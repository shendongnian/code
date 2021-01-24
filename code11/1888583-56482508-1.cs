    public class PersonCsvWriter
    {
        public void Write(List<Person> people, string path)
        {
            using (var file = new StreamWriter(path))
            {
                file.WriteLine("Name,,,Age,,,StreetAddress");
                people.ForEach(p => file.WriteLine($"{p.Name},,,{p.Age},,,{p.StreetAddress}"));
            }
        }
    }
