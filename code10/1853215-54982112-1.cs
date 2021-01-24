    public abstract class MonoBehaviourWithId : MonoBehaviour
    {
        public Guid UniqueId { get; }
        public MonoBehaviourWithId() 
        {
            UniqueId = Guid.NewGuid();
        }
    }
