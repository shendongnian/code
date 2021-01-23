    public class PcUsernameScore
    {
        public object PC;
        public string UserName;
        public float Score;
        public PcUsernameScore(object pc, string username, float score)
        {
             PC = pc; Username = username; Score = score;
        }
    }
    worker.ReportProgress(i, new PcUsernameScore(pc, username, score));
