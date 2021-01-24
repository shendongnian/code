    using UnityEngine;
    using System.Collections;
    
    public class PerlinTerrain : MonoBehaviour
    {
    
        public float perlinScale;
        public float waveSpeed;
        public float waveHeight;
        public float offset;
    
        Vector3[] baseVertices;
    
        private void OnEnable()
        {
            MeshFilter mF = GetComponent<MeshFilter>();
    
            baseVertices = mF.mesh.vertices;
        }
    
        void Update()
        {
            CalcNoise();
        }
    
        void CalcNoise()
        {
            MeshFilter mF = GetComponent<MeshFilter>();
    
            mF.sharedMesh.vertices = baseVertices;
            mF.sharedMesh.RecalculateNormals();
    
            Vector3[] verts = mF.sharedMesh.vertices;
    
            for (int i = 0; i < verts.Length; i++)
            {
                float pX = (verts[i].x * perlinScale) + (Time.timeSinceLevelLoad * waveSpeed) + offset;
                float pZ = (verts[i].z * perlinScale) + (Time.timeSinceLevelLoad * waveSpeed) + offset;
                verts[i] = verts[i] + ((Mathf.PerlinNoise(pX, pZ)) * waveHeight * mF.sharedMesh.normals[i].normalized);
            }
    
            mF.sharedMesh.vertices = verts;
        }
    }
