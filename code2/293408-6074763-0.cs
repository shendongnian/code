    public class VoteManager
    {
        public Dictionary<string, int> Votes { get; private set; }
        public VoteManager
        {
            Votes = new Dctionary<string, int>();
        }
        public void AddVotes(string name, int voteCount)
        {
            int oldCount;
            if (!Votes.TryGetValue(name, out oldCount))
                oldCount = 0;
            Votes[name] = oldCount + voteCount;
        }
