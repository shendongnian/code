    public class ExampleEditor : MonoBehaviour
    {
        private Animator animator;
    
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                animator.SetBool("Running", true);
                return;
            }
            animator.SetBool("Running", false);
    
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Walking", true);
                return;
            }
    
            animator.SetBool("Walking", false);
        }
    }
