    private Dictionary<string, int> votesByPeep; // initialized in constructor
    private void AddVotes(string peep, int votes)
    {
        if (this.votesByPeep.ContainsKey(peep)
        {
            this.votesByPeep[peep] += votes;
        }
        else
        {
            this.votesByPeep[peep] = votes;
        }
    }
