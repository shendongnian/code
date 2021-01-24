    public static string AsColumnString(Book book, int columnWidth = 0)
    {
        if (columnWidth < 1) columnWidth = book.Title.Length + 8;
        var name = book.Title.Substring(0, columnWidth - 8).PadRight(columnWidth - 5, '.');
        var date = book.PublishDate.ToString("MM-yy");
        return $"{name}{date}";
    }
