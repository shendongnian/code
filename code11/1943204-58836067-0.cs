        internal List<Highscore> Highscores { get; set; }
        public void LoadXmL(string path)
        {
            List<Highscore> highscores = null;
            XmlSerializer ser = new XmlSerializer(typeof(List<Highscore>));
            
            using (XmlReader reader = XmlReader.Create(path))
            {
                highscores = (List<Highscore>)ser.Deserialize(reader);
            }
            if (highscores == null)
            {
                highscores = new List<Highscore>
                {
                    new Highscore{ Name = "Alex", Score = 1000 },
                    new Highscore{ Name = "Chris", Score = 940 },
                    new Highscore{ Name = "Stefan", Score = 700 },
                };
            }
        }
        public class Highscore
        {
            public string Name { get; set; }
            public int Score { get; set; }
        }
        public Highscore GetHighest()
        {
            return Highscores.OrderByDescending(o => o.Score).First();
        }
