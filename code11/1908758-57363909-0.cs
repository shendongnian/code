    public IActionResult MusicDetails(int MusicID)
            {
                var varMusic = _db.Music.SingleOrDefault(aa => aa.Topicid == MusicID);
                Music obj = new Music();
                if(varMusic!=null)
                {
                    obj.Artist = varMusic.Artist;
                    obj.Title = varMusic.Title;
                    var varAlbum = _db.Album.Where(aa => aa.Topicid == MusicID);
                    List<Album> albumcollection = new List<Music>();
                    foreach(var item in varAlbum)
                    {
                        Album albumitem = new Album();
                        albumitem.item1 = item.item1;
                        albumitem.item2 = item.item2;
                        albumcollection.Add(albumitem);
                    }
                    obj.Album = albumcollection;
                }
                return Json(obj);
            }
