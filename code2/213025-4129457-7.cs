    public class plan {
        public plan(WorldState state) {
            state.IsUsedDelegate += CheckForItemUse;
        }
        public bool CheckForItemUse(Item item) {
             // Am I using it?
        }
    
    }
