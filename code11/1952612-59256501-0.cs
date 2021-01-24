            var here = albums.Where(a => a.UserId == 1).Select(b => new Album
                {
                    Id = b.Id,
                    Title = b.Title,
                    UserId = b.UserId,
                    Photos = photos.Where(a => a.AlbumId == b.Id).ToList()
                }).ToList();
