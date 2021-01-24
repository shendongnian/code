    partial class Form1 : Form
    {
        public String Main_Trunk;
        class EXP
        {
            string Inner_Trunk;
            public EXP(Form1 f1)
            {
                Inner_Trunk = f1.Main_Trunk;
            }
        }
        void Func()
        {
            EXP ei = new EXP(this);
        }
    }
