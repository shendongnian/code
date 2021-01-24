cs
string content = json.Replace("\n", "");
`Environment.NewLine` doesn't work here. There is a formatted content below
{
    "book": 
	{
        "publisher": "Pearson",
        "language": "Eng",
        "image": "https:\/\/images.isbndb.com\/covers\/34\/13\/9780134093413.jpg",
        "title_long": "Campbell Biology (11th Edition)",
        "edition": "11",
        "pages": 1488,
        "date_published": "2017",
        "subjects": ["Biology"],
        "authors": ["Lisa A. Urry", "Michael L. Cain", "Steven A. Wasserman", "Peter V. Minorsky", "Jane B. Reece"],
        "title": "Campbell Biology (11th Edition)",
        "isbn13": "9780134093413",
        "msrp": "259.99",
        "binding": "Hardcover",
        "publish_date": "2017",
        "isbn": "0134093410"
    }
}
Than copied the updated string and used **Edit-Paste Special-Paste JSON as classes**. There is generated classes
cs
    public class BookResponse
	{
		public Book book { get; set; }
	}
	public class Book
	{
		public string publisher { get; set; }
		public string language { get; set; }
		public string image { get; set; }
		public string title_long { get; set; }
		public string edition { get; set; }
		public int pages { get; set; }
		public string date_published { get; set; }
		public string[] subjects { get; set; }
		public string[] authors { get; set; }
		public string title { get; set; }
		public string isbn13 { get; set; }
		public string msrp { get; set; }
		public string binding { get; set; }
		public string publish_date { get; set; }
		public string isbn { get; set; }
	}
Actually, the `Book` instance is nested in a different class
