    using UnityEngine;
    
    public class CullingGroupBehaviour : MonoBehaviour
    {
    
        private CullingGroup cullingGroup;
        private BoundingSphere[] bounds;
    
        Transform[] targets;
        public Transform ReferencePoint;
    
        void Start()
        {
            // All the objects that have a sphere tag
            var gobjs = GameObject.FindGameObjectsWithTag("Sphere");
            targets = new Transform[gobjs.Length];
            for(int i = 0; i < gobjs.Length; i++)
            {
                targets[i] = gobjs[i].transform;
            }
    
            cullingGroup = new CullingGroup();
    
            cullingGroup.targetCamera = Camera.main;
            // Will automatically track the transform
            cullingGroup.SetDistanceReferencePoint(transform);
            // The distance points when the event will trigger
            cullingGroup.SetBoundingDistances(new float[] { 25.0f });
            // Creating Boundingspheres
            bounds = new BoundingSphere[targets.Length];
            for (int i = 0; i < bounds.Length; i++)
            {
                bounds[i].radius = 1.5f;
            }
            // Assigning the Bounding spheres
            cullingGroup.SetBoundingSpheres(bounds);
            // if not set it will use all of the array elements(so below code is redundant)
            cullingGroup.SetBoundingSphereCount(targets.Length);
            // Assigning an event when the distance changes
            cullingGroup.onStateChanged = OnChange;
        }
    
        void Update()
        {
            for (int i = 0; i < bounds.Length; i++)
            {
                bounds[i].position = targets[i].position;
            }
        }
    
        void OnDestroy()
        {
            cullingGroup.Dispose();
            cullingGroup = null;
        }
    
        void OnChange(CullingGroupEvent ev)
        {
            if (ev.currentDistance > 0)
            {
                targets[ev.index].gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                targets[ev.index].gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
