    public class MyForm
    {
        Random rand = new Random();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            AnswerValue.Visibility = Visibility.Collapsed;
            Load();
        }
        private void Load()
        {
            int random = rand.Next(1, 4);
            DisplayChallenge(ChallengeFactory.GetChallenge(random));
        }
    
        private void DisplayChallenge(ChallengeFactory.Challenge challengeToDisplay)
        {
            DifficultyValue.Text = String.Format("{0}%", challengeToDisplay.Difficulty);
            CompletionValue.IsChecked = challengeToDisplay.IsChecked;
            TitleValue.Text = challengeToDisplay.Title;
            QuestionValue.Text = challengeToDisplay.Question;
            ImageValue.Source = challengeToDisplay.ImageSource;
            ImageValue.Visibility = challengeToDisplay.Visible;
            ResourceValue.Text = challengeToDisplay.ResourceValue;
            AnswerValue.Text = challengeToDisplay.Answer;
        }
    }
