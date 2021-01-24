    var result = flatManyToMany
        .GroupBy(f1 => (f1.BookTitle, f1.BookPages))
        .Select(g1 => (bookInfo: g1.Key,
                        readers:
                            g1.Select(f2 => new Reader { Name= f2.ReaderName, Age= f2.ReaderAge }),
                        readerKey:
                            String.Join("|", g1.Select(f3 => $"{f3.ReaderName},{f3.ReaderAge}"))))
        // So far we have an:
        // IEnumerable<((string BookTitle, int BookPages) bookInfo, 
        //    IEnumerable<Reader> readers, string readerKey)>
        .GroupBy(a1 => a1.readerKey)
        .Select(g2 => new ResultDoubleList {
            Books = g2.Select(a2 => new Book {
                Title = a2.bookInfo.BookTitle,
                Pages = a2.bookInfo.BookPages
            }
                ).ToList(),
            Readers = g2.First().readers.ToList()
        })
        .ToList();
