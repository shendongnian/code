        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<QuestionType> Questions = new ObservableCollection<QuestionType>()
            {
                new TextBoxQuestion() { Question = "What's your favorite color?" },
                new CheckBoxQuestion() { Question = "Are you allergic to peanuts?" },
                new ComboBoxQuestion() { Question = "How many fingers am I holding up?",
                    Values = new List<string>() { "1", "2", "3", "4", "6" }}
            };
            QuestionList.ItemsSource = Questions;
        }
