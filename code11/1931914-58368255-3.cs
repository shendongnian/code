    public class Book
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public DateTime PublishedDate { get; set; }
    }
    // deserialize into classes
    var data = JsonConvert.DeserializeObject<RootObject>(json);	
    // transform to List<Book>	
	var myBooks = data.Items
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
