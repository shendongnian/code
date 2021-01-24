    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Tile : MonoBehaviour
    {
        public int X;
        public int Y;
    
        private Renderer m_Renderer;
    
    
        private void Awake() {
            this.m_Renderer = this.GetComponent<Renderer>();
        }
        
        public void SetPosition(int x, int y) {
            this.X = x;
            this.Y = y;
    
            this.transform.position = new Vector3(x, y, 0);
        }
        public void SetColor(Color c) {
            m_Renderer.material.color = c;
        }
    }
