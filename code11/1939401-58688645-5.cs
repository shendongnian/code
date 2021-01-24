    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityStandardAssets.CrossPlatformInput;
    
    public class PlayerControl : MonoBehaviour
    {
        // We gonna move by WASD keys
    
        [Header("Speed & Movement settings")]
        [SerializeField]
        float Speed = 2.0f;
        [SerializeField]
        float movSpeedX = 0.8f;
        [SerializeField]
        float movSpeedY = 2.4f;
    
        bool ReachedTarget = true;
    
        void Update()
        {
            if(ReachedTarget){
                Vector2 dest;
                if(Input.GetKeyUp(KeyCode.W)){
                    dest = transform.position + (Vector2.up * movSpeedY);
                }
                else if(Input.GetKeyUp(KeyCode.S)){
                    dest = transform.position + (Vector2.down * movSpeedY);
                }
                else if(Input.GetKeyUp(KeyCode.D)){
                    dest = transform.position + (Vector2.right * movSpeedY);
                }
                else if(Input.GetKeyUp(KeyCode.A)){
                    dest = transform.position + (Vector2.left * movSpeedY);
                }
                StartCoroutine(moveTo(dest, Speed));
            }
        }
    
        // Time to take is in seconds
        IEnumerator moveTo(Vector2 TargetPosition, float TimetoTake)
        {
            Vector2 originalPosition = transform.position;
            float Time_taken = 0f;
            ReachedTarget = false;
            while (Time_taken < 1)
            {
                Time_taken += Time.deltaTime / TimetoTake;
                // Interpolating between the original and target position this basically provides your "speed"
                transform.position = Vector2.Lerp(originalPosition, TargetPosition, Time_taken);
                yield return null;
            }
            Time_taken = 0;
            transform.position = TargetPosition;
            ReachedTarget = true;
        }
    }
