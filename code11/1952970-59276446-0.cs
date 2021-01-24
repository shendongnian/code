    using UnityEngine;
    using UnityStandardAssets.CrossPlatformInput;
    using UnityStandardAssets.Utility;
    using Random = UnityEngine.Random;
    
    namespace UnityStandardAssets.Characters.FirstPerson
    {
        [RequireComponent(typeof (CharacterController))]
        public class FirstPersonController : MonoBehaviour
        {
            [SerializeField] private float m_RunSpeed;
    
            private CharacterController m_CharacterController;
    
            // Use this for initialization
            private void Start()
            {
                m_CharacterController = GetComponent<CharacterController>();
            }
    
            private void FixedUpdate()
            {
                Vector3 move = Vector3.right * m_RunSpeed;
                Physics.SyncTransforms();
                m_CharacterController.Move(move * Time.fixedDeltaTime);
            } 
        }
    }
