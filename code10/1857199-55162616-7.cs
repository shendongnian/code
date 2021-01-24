        public partial class HighScoresMenu : Form
    {
        foreach (Player players in MainMenu.GetPlayers(newScore, newPoints, 
        PlayersName))
        {
            ListBoxLevel1.Items.Add(players.getName());
        }
    } 
