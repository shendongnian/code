    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class CapsuleMesh : MonoBehaviour
    {    
        public Mesh Mesh
        {
           get ; private set;
        }
    
        void Awake()
        {
            Mesh = GetComponent<MeshFilter>().mesh;
        }
    }
----
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ChangeMesh : MonoBehaviour
    {
        // Drag & drop in the inspector the gameObject holding the `CapsuleMesh` component
        public CapsuleMesh CapsuleMesh;
    
        private MeshFilter meshFilter;
    
        void Awake()
        {
            meshFilter = GetComponent<MeshFilter>();
        }
        void Start()
        {
            meshFilter.mesh = CapsuleMesh.Mesh;    
        }
    }
