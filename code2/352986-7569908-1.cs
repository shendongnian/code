    public class Skill
    {
        int ability, rank, misc;
        public Skill(int ability, int rank, int misc)
        {
            this.ability = ability;
            this.rank = rank;
            this.misc = misc;
        }
        public int Score { get { return ability + rank + misc; }
    }
    Skill balance = new Skill(10, 1, 1);
    textBalance.Text = balance.Score.ToString();
    Skill programming = new Skill(10, 100, 0);
    textProgramming.Text = programming.Score.ToString();
