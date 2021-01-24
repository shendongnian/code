csharp
public static void Main(string[] args)
{
    var records = GetRecords();
    using (var csv = new CsvWriter(Console.Out))
    {
        csv.Configuration.RegisterClassMap<PersonMap>();
        csv.Configuration.RegisterClassMap<BookMap>();
        csv.Configuration.RegisterClassMap<PageMap>();
        csv.WriteHeader<PersonDTO>();
        csv.WriteHeader<Book>();
        csv.WriteHeader<Page>();
        csv.NextRecord();
        foreach (var person in records)
        {
            foreach (var book in person.Books)
            {
                foreach (var page in book.Pages)
                {
                    csv.WriteRecord(person);
                    csv.WriteRecord(book);
                    csv.WriteRecord(page);
                    csv.NextRecord();
                }
            }
        }
    }
    Console.ReadKey();
}
public sealed class PersonMap : ClassMap<PersonDTO>
{
    public PersonMap()
    {
        Map(m => m.Id).Name("PersonId");
        References<PersonDetailsMap>(m => m.details);
    }
}
public sealed class PersonDetailsMap : ClassMap<PersonDetails>
{
    public PersonDetailsMap()
    {
        Map(m => m.FName);
        Map(m => m.LName);
    }
}
public sealed class BookMap : ClassMap<Book>
{
    public BookMap()
    {
        Map(m => m.Id).Name("BookId");
        Map(m => m.Name).Name("BookName");
    }
}
public sealed class PageMap : ClassMap<Page>
{
    public PageMap()
    {
        Map(m => m.Id).Name("PageId");
    }
}
