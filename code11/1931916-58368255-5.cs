    public class Book
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public DateTime PublishedDate { get; set; }
    }
    // deserialize into classes
    var response = JsonConvert.DeserializeObject<RootObject>(data);	
    // project to List<Book>	
	var myBooks = response.Items
                      .Select(d => new Book 
                      { 
                          Title = d.VolumeInfo.Title, 
                          Authors = string.Join(",", d.VolumeInfo.Authors), 
                          PublishedDate = d.VolumeInfo.PublishedDate 
                      })
                      .ToList();		
	foreach (var book in myBooks)
	{
		Console.WriteLine($"Title: {book.Title}, Authors: {book.Authors}, Date: {book.PublishedDate}"); 
	}
