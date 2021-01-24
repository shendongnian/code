    using System;
    using UnityEngine;
    using Object = UnityEngine.Object;
    
    public class Example : MonoBehaviour
    {
        // set on runtime and destroyed -> should be missing
        public Renderer renderer;
    
        // never set -> should be null
        public Collider collider;
    
        private void Awake()
        {
            renderer = GetComponent<Renderer>();
            Destroy(renderer);
        }
    
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
    
            CheckReference(renderer); // should be missing
            CheckReference(collider); // should be null
        }
    
        public void CheckReference(Object reference)
        {
            try
            {
                var blarf = reference.name;
            }
            catch (MissingReferenceException)
            {
                Debug.LogError("The provided reference is missing!");
            }
            catch (MissingComponentException)
            {
                Debug.LogError("The provided reference is missing!");
            }
            catch (UnassignedReferenceException)
            {
                Debug.LogWarning("The provided reference is null!");
            }
            catch (NullReferenceException)
            {
                Debug.LogWarning("The provided reference is null!");
            }
        }
    }
