    public List<Submission> GetRandomWinners(int competitionId, Random rng)
    {
        List<Submission> submissions = new List<Submission>();
        int winnerCount = DbContext().Competitions
                                     .Single(s => s.CompetitionId == competitionId)
                                     .NumberWinners;
        var correctEntries = DbContext().Submissions
                                        .Where(s => s.CompetitionId == id && 
                                                    s.CorrectAnswer)
                                        .ToList();
        return correctEntries.Shuffle(rng).Take(winnerCount).ToList();
    }
