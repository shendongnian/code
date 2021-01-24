    public class ScriptB : MonoBehaviour
    {
        // What does this script have, ScriptA didn't?
        [Header("Additional Components")]
        // The two components you want to check the bool for
        public ScriptA FirstToCheck;
        public ScriptA SecondToCheck;
        [Space]
        // The component you want to destroy
        public ScriptA ToDestroy;
    
        // Overwrite/Extend the behaviour of HandleClick
        protected virtual void HandleClick()
        {
            if(!FirstToCheck.WasClicked) return;
            if(!SecondToCheck.WasClicked) return;
    
            // Do what the parent implemented
            // in this case set my bool and change my color
            base.HandleClick();
    
            Destroy(ToDestroy.gameObject);
        }
    }
