    // Note: This example is simplified for readability
    // Here is the common data structure that can represent all challenges
    private class Challenge
    {
        public string Title { get; set; }
        public string Question { get; set; }
        public string ImagePath { get; set; }
    }
    // All of the challenges are defined right here, as simple data
    private Challenge[] _allChallenges = new Challenge[]
    {
        new Challenge
        {
            Title = "Chicken or Egg?",
            Question = "Can you answer the ancient question: Which came first the chicken of the egg?",
            ImagePath = "Images/Challenge1.png",
        },
        new Challenge
        {
            Title = "Halving Seven?",
            Question = "Can you prove that seven is half of twelve?",
            ImagePath = "Images/Challenge1.png",
        },
    }
    // Choosing challenges is as simple as indexing into the array
    private void Load()
    {
        int random = rand.Next(1, 4);
        Challenge chosenChallenge = _allChallenges[random];
        LoadChallenge(chosenChallenge);
    }
    // Setting up the UI for a challenge means extracting information from the data structure
    private void LoadChallenge(Challenge chosenChallenge)
    {
        TitleValue.Text = chosenChallenge.Title;
        QuestionValue.Text = chosenChallenge.Text;
        bmp.UriSource = new Uri(chosenChallenge.ImagePath, UriKind.Relative);
        ImageValue.Source = bmp;
        ImageValue.Visibility = Visibility.Visible;
    }
