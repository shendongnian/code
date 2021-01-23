    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Title, Title) && Equals(other.Author, Author) && Equals(other.Chapters, Chapters);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Book)) return false;
            return Equals((Book) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Title != null ? Title.GetHashCode() : 0);
                result = (result*397) ^ (Author != null ? Author.GetHashCode() : 0);
                result = (result*397) ^ (Chapters != null ? Chapters.GetHashCode() : 0);
                return result;
            }
        }
    }
