    //I'd call it Stage, or the stages field below items for consistency
    //but I took your names :D
    public class Item
    {
        //It's kinda better to store the right thing right away
        //unless ofc you need the GameObject reference for something you didnt mention
        public BoxCollider[] puzzles; 
        public BoxCollider[] clues;
        // ... and so on
    
        public void SetActive(bool activate) {
            foreach(var puzzle in puzzles) {
                puzzle.enabled = activate;
            }
            foreach(var clue in clues) {
                clue.enabled = activate;
            }
            // ... same for the other stuff
            // Basically, everything that has to do with activation/deactivation
            // of the stage goes in here
        }
    }
