    public class Contest
    {
        static readonly Random rng = new Random();
        public Contest(int n_participants)
        {
            this.Votes = new int[n_participants];
        }
        public int Participants => Votes.Length;
        public int[] Votes { get; }
        public int TotalVotes => Votes.Sum();
        public void VoteFor(int index)
        {
            this.Votes[index] += 1;
        }
        public void VoteRandom()
        {
            int index = rng.Next(0, Votes.Length);
            VoteFor(index);
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            // Singing contest with 20 participants.
            var singing_contest = new Contest(20);
            // Gather 1000 random votes
            for (int i = 0; i < 1000; i++)
            {
                singing_contest.VoteRandom();
            }
            // Tally up the votes
            for (int i = 0; i < singing_contest.Participants; i++)
            {
                Console.WriteLine($"Participant# : {i+1}, Votes = {singing_contest.Votes[i]}");
            }
            Console.WriteLine($"Total Votes = {singing_contest.TotalVotes}");
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }
    }
