    public class PlayerMovement : MonoBehaviour, INullReferenceChecker
    {
        ...
        
        public override void CheckReferences()
        {
            UnityEngine.Assertions.Assert.IsNotNull(gameManager, "Member \"gameManager\" is required.");
            UnityEngine.Assertions.Assert.IsNotNull(playerRigidBody, "Member \"Rigidbody\" is required.");
            // you could also simply go for
            if(!gameManager) Debug.LogErrorFormat(this, "Member \"{0}\" is required.", nameof(gameManager));
            if(!playerRigidBody) Debug.LogErrorFormat(this, "Member \"{0}\" is required.", nameof(playerRigidBody));
        }
    }
