    private Dictionary<string, int> votes; // initialized in constructor
    private void AddVotes(string peep, int votes)
    {
        if (this.votes.ContainsKey(peep)
        {
            this.votes[peep] += votes;
        }
        else
        {
            this.votes[peep] = votes;
        }
    }
