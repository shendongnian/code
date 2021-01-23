    public partial class Form2 : Form
    {
        string _highestScoreUser = string.Empty;
        public Form2()
        {
        
        }
        
        public string HighestScoreUser
        {
            get{ return _highestScoreUser; } 
            set{ _highestScoreUser = value; }
        }
    }
