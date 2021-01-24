    public class Item
    {
        //its kinda better to store the thing right away
        //unless ofc you need the GameObject reference for something you didnt mention
        public BoxCollider[] puzzles; 
        // ... same for the other stuff
    
        public void SetActive(bool activate) {
            foreach(var puzzle in puzzles) {
                puzzle.enabled = activate;
            }
            // ... same for the other stuff
        }
    }
