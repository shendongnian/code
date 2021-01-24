 cs
List<Player> players = new List<Player>();
while ((line = reader.ReadLine()) != null) {
    string[] playerInfo = line.Split(';');
    int ID = int.Parse(playerInfo[0]);
    string firstName = playerInfo[1];
    string lastName = playerInfo[2];
    DateTime dob = DateTime.Parse(playerInfo[3]);
    players.Add(new Player(id, firstName, lastName, dob);
}
If you want to have access to the list more globally you could do it this way:
Let's assume your class name is Sample:
cs
public class Sample {
    // Declare the list as a private field
    private List<Player> players;
    
    // Constructor - Creates the List instance
    public Sample() {
        players = new List<Player>();
    }
    private void openFileDialog_Click(object sender, EventArgs e) {
        players.Clear(); //Clears the list
        if (myOpenFileDialog.ShowDialog() == DialogResult.OK) ;
        using (FileStream fStream = File.OpenRead(myOpenFileDialog.FileName)) {
            StreamReader reader;
            reader = new StreamReader(fStream);
            string line;
            while ((line = reader.ReadLine()) != null) {
                string[] playerInfo = line.Split(';');
                int ID = int.Parse(playerInfo[0]);
                string firstName = playerInfo[1];
                string lastName = playerInfo[2];
                DateTime dob = DateTime.Parse(playerInfo[3]);
                players.Add(new Player(id, firstName, lastName, dob);
            }
        }
    }
}
    
Declaring the list this way you'll be able to get the values of the list from other methods inside the same class. 
