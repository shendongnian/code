    public class PlayerLivesDisplay : MonoBehaviour
    {
        ...
        public int PlayerdmgAmount { get; set; }
        ...
        public void takeLives(int playerdmgAmount)
        {
            ...
            this.PlayerdmgAmount = playerdmgAmount;
        }
    }
