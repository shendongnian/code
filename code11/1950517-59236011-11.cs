     public class EpisodeServices : IEpisodeService
    {
        public IList<Episode> GetEpisodes()
        {
            return new List<Episode>
            {
                new Episode { Id = 1, Name = "Imposter Syndrome", Description = "Imposter syndrome" }
            };
        }
    }
