    class Program
    {
        static void Main(string[] args)
        {
            using (MusicContainer music = new MusicContainer())
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    Artist artist = new Artist { Name = "Test" };
                    music.Artists.AddObject(artist);
                    music.SaveChanges();
                }
                // The transaction ended without Complete(); the changes are abandoned?
            }
        }
    }
