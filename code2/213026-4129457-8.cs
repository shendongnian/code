    delegate bool IsUsedDelegate(Item Item);
    public class WorldState {
        public IsUsedDelegate CheckIsUsed;
        public bool RemoveItem(Item item) {
            if (CheckIsUsed != null) {
                foreach (IsUsedDelegate checkDelegate in CheckIsUsed.GetInvocationList()) {
                    if (checkDelegate(item)) {
                        return false;  // or throw exception
                    }
                }
            }
            //  Remove the item
            return true;
        }
    }
