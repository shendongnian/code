    private void Leaderboard_Load(object sender, EventArgs e)
        {
    
            string[] scores = File.ReadAllLines(filepath); //filepath is equal to @database.txt file
            var orderedScores = scores.OrderByDescending(x => int.Parse(x.Split(',')[1]));
            foreach (var entry in orderedScores)
            {
                Console.WriteLine(entry);
            }
    
            StreamReader sr = new StreamReader(@"database.txt");
            while (line != null)
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    scoreboard.Items.Add(line);
                }
            }
            sr.Close();
        }
