    //I'd call it Stage, or the stage field below item for consistency
    //but i took your names :D
    public class Item
    {
        //its kinda better to store the thing right away
        //unless ofc you need the GameObject reference for something you didnt mention
        public BoxCollider[] puzzles; 
        public BoxCollider[] clues;
        // ... same for the other stuff
    
        public void SetActive(bool activate) {
            foreach(var puzzle in puzzles) {
                puzzle.enabled = activate;
            }
            foreach(var clue in clues) {
                clue.enabled = activate;
            }
            // ... same for the other stuff
        }
    }
