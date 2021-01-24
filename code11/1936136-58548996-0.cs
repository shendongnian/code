        static void Main(string[] args)
        {
            List<Book> lstBooks = GetBooks();
            StringBuilder books = new StringBuilder();
            books = books.AppendLine("Book    Date    Book    Date");
            string dots = "........";
            foreach (Book b in lstBooks)
            {
                string neededDots = dots;
                for (int i = 1; i <= b.Name.Length; i++)
                {
                    if (i > 0 && neededDots.Length > 1)
                    {
                        neededDots = neededDots.Remove(0, 1);
                    }
                }
                books.AppendLine(b.Name + neededDots.PadLeft(5 - b.CompletedDate.Length) + b.CompletedDate
                    + "   "
                    + b.Name + neededDots.PadLeft(5 - b.CompletedDate.Length) + b.CompletedDate);
            }
            Console.WriteLine(books);
            Console.Read();
        }
