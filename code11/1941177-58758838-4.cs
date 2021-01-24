class ReadersComparer : IEqualityComparer<List<Reader>>
{
    public bool Equals(List<Reader> a, List<Reader> b) => Enumerable.SequenceEqual(a, b); // Please note this doesn't order the lists so you either need to order them before, or order them here and implement IComparable on the Reader class
    public int GetHashCode(List<Reader> os)
    {
        int hash = 19;
        foreach (var o in os) { hash = hash * 31 + o.GetHashCode(); }
        return hash;
    }
}
public class Reader : IEquatable<Reader>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public override int GetHashCode() => (Name, Age).GetHashCode();
    public bool Equals(Reader other) => (other is null) ? false : this.Name == other.Name && this.Age == other.Age;
    public override bool Equals(object obj) => Equals(obj as Reader);
}
static void Main(string[] args)
{
var actsOfReading = new[]{
    new Reading { BookTitle = "How to Do This Double List", BookPages = 105, ReaderName = "Kyle", ReaderAge = 29},
    new Reading { BookTitle = "How to Do This Double List", BookPages = 105, ReaderName = "Bob", ReaderAge = 34},
    new Reading { BookTitle = "Gone With Jon Skeet", BookPages = 192, ReaderName = "Kyle", ReaderAge = 29},
    new Reading { BookTitle = "Gone With Jon Skeet", BookPages = 192, ReaderName = "James", ReaderAge = 45},
    new Reading { BookTitle = "Gone With Jon Skeet", BookPages = 192, ReaderName = "Brian", ReaderAge = 15},
    new Reading { BookTitle = "Why Is This So Hard?", BookPages = 56, ReaderName = "Kyle", ReaderAge = 29},
    new Reading { BookTitle = "Why Is This So Hard?", BookPages = 56, ReaderName = "James", ReaderAge = 45},
    new Reading { BookTitle = "Why Is This So Hard?", BookPages = 56, ReaderName = "Brian", ReaderAge = 15},
    new Reading { BookTitle = "Impostor Syndrome", BookPages = 454, ReaderName = "Kyle", ReaderAge = 29},
    new Reading { BookTitle = "Self Doubt and You", BookPages = 999, ReaderName = "Kyle", ReaderAge = 29}
};
var booksReadByGroups = actsOfReading.GroupBy(a => a.BookTitle)
    .Select(g => new
    {
        Book = new Book { Title = g.Key, Pages = g.Max(a => a.BookPages) },
        Readers = g.Select(a => new Reader { Name = a.ReaderName, Age = a.ReaderAge }).ToList()
    })
    .GroupBy(b => b.Readers, new ReadersComparer())
    .Select(g => new
    {
        Books = g.Select(b => b.Book),
        Readers = g.First().Readers
    })
    .ToList();
    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(booksReadByGroups));
}
*Output (manually formatted)*
[{
 "Books": [{
 "Title": "How to Do This Double List", "Pages": 105 }
 ],
 "Readers": [{
 "Name": "Kyle", "Age": 29 }, {
 "Name": "Bob", "Age": 34 }
 ]
}, {
 "Books": [{
 "Title": "Gone With Jon Skeet", "Pages": 192 }, {
 "Title": "Why Is This So Hard?", "Pages": 56 }
 ],
 "Readers": [{
 "Name": "Kyle", "Age": 29 }, {
 "Name": "James", "Age": 45 }, {
 "Name": "Brian", "Age": 15 }
 ]
}, {
 "Books": [{
 "Title": "Impostor Syndrome", "Pages": 454 }, {
 "Title": "Self Doubt and You", "Pages": 999 }
 ],
 "Readers": [{
 "Name": "Kyle", "Age": 29 }
 ]
}
]
# Books with readers
var booksReadByGroups = actsOfReading.GroupBy(a => a.BookTitle)
    .Select(g => new
    {
        Book = new Book { Title = g.Key, Pages = g.Max(a => a.BookPages) },
        Readers = g.Select(a => new Reader { Name = a.ReaderName, Age = a.ReaderAge }).ToList()
    })
    .ToList();
## Test
var o = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
var actsOfReading = new[]{
    new Reading { BookTitle = "How to Do This Double List", BookPages = 105, ReaderName = "Kyle", ReaderAge = 29},
    new Reading { BookTitle = "How to Do This Double List", BookPages = 105, ReaderName = "Bob", ReaderAge = 34},
    new Reading { BookTitle = "Gone With Jon Skeet", BookPages = 192, ReaderName = "Kyle", ReaderAge = 29},
    new Reading { BookTitle = "Gone With Jon Skeet", BookPages = 192, ReaderName = "James", ReaderAge = 45},
    new Reading { BookTitle = "Gone With Jon Skeet", BookPages = 192, ReaderName = "Brian", ReaderAge = 15},
    new Reading { BookTitle = "Why Is This So Hard?", BookPages = 56, ReaderName = "Kyle", ReaderAge = 29},
    new Reading { BookTitle = "Why Is This So Hard?", BookPages = 56, ReaderName = "James", ReaderAge = 45},
    new Reading { BookTitle = "Why Is This So Hard?", BookPages = 56, ReaderName = "Brian", ReaderAge = 15},
    new Reading { BookTitle = "Impostor Syndrome", BookPages = 454, ReaderName = "Kyle", ReaderAge = 29},
    new Reading { BookTitle = "Self Doubt and You", BookPages = 999, ReaderName = "Kyle", ReaderAge = 29}
};
var booksReadByGroups = actsOfReading.GroupBy(a => a.BookTitle)
    .Select(g => new
    {
        Book = new Book { Title = g.Key, Pages = g.Max(a => a.BookPages) },
        Readers = g.Select(a => new Reader { Name = a.ReaderName, Age = a.ReaderAge }).ToList()
    })
    .ToList();
Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(booksReadByGroups, o));
### Output 
*(Manually formatted)*
[
 { "Book": { "Title": "How to Do This Double List", "Pages": 105 },
 "Readers": [
	{ "Name": "Kyle", "Age": 29 },
	{ "Name": "Bob", "Age": 34 }
 ]
 },
 { "Book": { "Title": "Gone With Jon Skeet", "Pages": 192 },
 "Readers": [
	{ "Name": "Kyle", "Age": 29 },
	{ "Name": "James", "Age": 45 },
	{ "Name": "Brian", "Age": 15 }
 ]
 },
 { "Book": { "Title": "Why Is This So Hard?", "Pages": 56 },
 "Readers": [
	{ "Name": "Kyle", "Age": 29 },
	{ "Name": "James", "Age": 45 },
	{ "Name": "Brian", "Age": 15 }
 ]
 },
 { "Book": { "Title": "Impostor Syndrome", "Pages": 454 },
 "Readers": [
	{ "Name": "Kyle", "Age": 29 }
 ]
 },
 { "Book": { "Title": "Self Doubt and You", "Pages": 999 },
 "Readers": [
	{ "Name": "Kyle", "Age": 29 }
 ]
 }
]
# Books and readers
var books = actsOfReading.GroupBy( a => a.BookTitle )
        .Select( g => new Book{Title = g.Key, Pages = g.Max(b => b.BookPages)})
        .ToList();
var readers = actsOfReading.GroupBy( a => a.ReaderName )
        .Select( g => new Reader{Name = g.Key, Age = g.Max(b => b.ReaderAge)})
        .ToList();
# Test
var books = actsOfReading.GroupBy( a => a.BookTitle )
        .Select( g => new Book{Title = g.Key, Pages = g.Max(b => b.BookPages)})
        .ToList();
var readers = actsOfReading.GroupBy( a => a.ReaderName )
        .Select( g => new Reader{Name = g.Key, Age = g.Max(b => b.ReaderAge)})
        .ToList();
        var o = new System.Text.Json.JsonSerializerOptions{WriteIndented =true};
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(books,o));
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(readers,o));
## Output
*(manually formatted)*
[
 { "Title": "How to Do This Double List", "Pages": 105 },
 { "Title": "Gone With Jon Skeet", "Pages": 192 },
 { "Title": "Why Is This So Hard?", "Pages": 56 },
 { "Title": "Impostor Syndrome", "Pages": 454 },
 { "Title": "Self Doubt and You", "Pages": 999 }
]
[
 { "Name": "Kyle", "Age": 29 },
 { "Name": "Bob", "Age": 34 },
 { "Name": "James", "Age": 45 },
 { "Name": "Brian", "Age": 15 }
]
