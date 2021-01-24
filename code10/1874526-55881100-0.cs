                foreach (var item in files)
                {
                    string path = item.ToString();
                    string title = path.Replace(remove[0] + remove[1], "");
                    var newMovie = new Movie
                    {
                        IMDBId = 0123,
                        Title = title,
                        FilePath = path,
                        Year = "2007"
                    };
                    _context.Add(newMovie);
                    _context.SaveChanges();
                }
