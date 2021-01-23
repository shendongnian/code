    public abstract class CMonster
    {
        int _HP;
        int _MP;
        //..and something like this
        public int HP
        {
            get { return this._HP; }
            set { this._HP=value;}
        }
        public int MP
        {
            get { return this._MP; }
            set { this._MP = value; }
        }
        public abstract void Run();
        public abstract void Attach();
        public abstract void CastSpell();
    }
    public class CUgly_Spider : CMonster
    {
        public CUgly_Spider()
        {
            this.MP = 100;//your value here
            this.HP = 100;//your value here
        }
        public override void Attach()
        {
            //your implemetation here
        }
        public override void Run()
        {
            //your implemetation here
        }
        public override void CastSpell()
        {
            //your implemetation here
        }
    }
    public class CGollum : CMonster
    {
        public CGollum()
        {
            this.MP = 100;//your value here
            this.HP = 100;//your value here
        }
        public override void Attach()
        {
            //your implemetation here
        }
        public override void Run()
        {
            //your implemetation here
        }
        public override void CastSpell()
        {
            //your implemetation here
        }
    }
    class Test
    {
        private void InitTheGame()
        {
            CMonster curMonster=null;
            Random rnd = new Random();
            //sample random
            if ((rnd.Next() % 2) == 0)
            {
                curMonster = new CGollum();
            }
            else
            {
                curMonster = new CUgly_Spider();
            }
            curMonster.Run();//when (rnd.Next() % 2) == 0 then the Gollum is doing else the Ugly_Spider
            curMonster.Attach();//when (rnd.Next() % 2) == 0 then the Gollum is doing else the Ugly_Spider
            curMonster.CastSpell();//when (rnd.Next() % 2) == 0 then the Gollum is doing else the Ugly_Spider
        }
    }
