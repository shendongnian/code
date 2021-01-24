    public class ExampleEditor : MonoBehaviour
    {
        private Animator animator;
    
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                animator.Play("Running");
                return;
            }
    
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                animator.Play("Walking");
                return;
            }
    
            animator.Play("Idle");
        }
    }
