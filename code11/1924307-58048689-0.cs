		class Parent
        {
            public int Version { get; set; }
            public List<Manga> mangas { get; set; }
        }
       
        class Manga
        {
            public List<object> manga { get; set; }
            public List<Chapter> chapters { get; set; }
        }
        class Chapter
        {
            public  string u { get; set; }
            public int r { get; set; }
        }
        void createJson(String manganame, string mId, String mangaoid, long sourceid)
        {
            var json = new Parent()
            {
                Version = 2,
                mangas = new List<Manga>()
                {
                    new Manga()
                    {
                        manga = new List<object>{ "/manga/"+mangaoid, manganame, sourceid, 0, 0 },
                        chapters = Chapters(),
                    }
                }
            };
            var sjson = JsonConvert.SerializeObject(json, Formatting.Indented);
            File.WriteAllText(@"C:\Users\Izurii\Desktop\oi.json", sjson);
        }
        List<Chapter> Chapters()
        {
            List<Chapter> chapters = new List<Chapter>();
            for(int i = 0; i < links.Count; i ++)
            {
                chapters.Add(
                new Chapter()
                {
                    u = links[i],
                    r = 1,
                });
                
            }
            return chapters;
        }
