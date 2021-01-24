    using System.Collections;
    using UnityEngine;
    
    public class JumpExample : MonoBehaviour
    {
        static bool canJump = true;
        public float jumpCooldown = 3f;
    
    
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space) && canJump)
            {
                // Put your jump code here.
                StartCoroutine(CoolDownFunction());
            }
        }
        IEnumerator CoolDownFunction()
        {
            canJump = false;
            yield return new WaitForSeconds(jumpCooldown);
            canJump = true;
        }
    
    }
