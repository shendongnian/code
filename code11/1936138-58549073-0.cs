    public class Book
    {
        public string Name { get; set; }
        public DateTime CompletedDate { get; set; }
    }
    List<Book> lstBooks = new List<Book>
    {
        new Book { Name = "ABC", CompletedDate = DateTime.Now },
        new Book { Name = "1ABC", CompletedDate = DateTime.Now },
        new Book { Name = "XYZ", CompletedDate = DateTime.Now },
        new Book { Name = "2XYZ", CompletedDate = DateTime.Now },
        new Book { Name = "123ABC", CompletedDate = DateTime.Now },
    };
     
    StringBuilder sBuilder = new StringBuilder();
    string title = " Book    Date    Book    Date ";
    string completedDateFormat = "MM-dd";
    sBuilder.AppendLine(title);
    
    for (int i = 1, max = lstBooks.Count; i < max; i += 2)
    {
        sBuilder.AppendLine(string.Join(string.Empty.PadRight(4, ' '),
            string.Join(string.Empty.PadRight(4, '.'), lstBooks[i - 1].Name, lstBooks[i - 1].CompletedDate.ToString(completedDateFormat)),
            string.Join(string.Empty.PadRight(4, '.'), lstBooks[i].Name, lstBooks[i - 1].CompletedDate.ToString(completedDateFormat))));
    }
     
    // Determine if Last record is accounted for by loop logic by looking at the remainder of a modular operation
    var appendLastRecord = lstBooks.Count % 2 == 0;
    sBuilder.AppendLine(string.Join(string.Empty.PadRight(4, '.'), lstBooks.Last().Name, lstBooks.Last().CompletedDate.ToString(completedDateFormat)));
     
    Console.Write(sBuilder.ToString());
