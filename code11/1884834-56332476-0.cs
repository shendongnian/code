    private string SameSize(int Maxsize, string team)
    {
            if (team.Length < Maxsize)
                return SameSize(Maxsize, team + ".");
            else
                return team;
    }
    var maxlength = teams.OrderByDescending(x => x.Name.Length).First().Length + 4;
    
    rankingTextBox.Text += $"{i + 1}.  {SameSize(maxlength,teams[i].Name)} {teams[i].Points}\n";
