    delegate bool IsUsedDelegate(Item Item);
    public class WorldState {
        public IsUsedDelegate CheckIsUsed;
        public bool RemoveItem(Item Item) {
            if (CheckIsUsed != null) {
                foreach (IsUsedDelegate checkDelegate in CheckIsUsed.GetInvocationList()) {
                    if (checkDelegate(Item)) {
                        return false;  // or throw exception
                    }
                }
            }
            //  Remove the item
            return true;
        }
    }
