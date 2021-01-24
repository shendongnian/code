    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Grid : MonoBehaviour
    {
        public int gridSize = 10;
        public Tile tilePrefab;
    
        void Start() {
            SetGrid();
        }
    
        public void SetGrid() {
            int total = gridSize * gridSize;
    
            for(int i = 0; i < total; i++) {
                int posX = (int)Mathf.Floor(i/gridSize);
                int posY = i % gridSize;
    
                Tile t = Instantiate(tilePrefab).GetComponent<Tile>();
                t.SetPosition(posX, posY);
    
                if((posX + posY) % 2 == 0)
                    t.SetColor(Color.blue);
                else
                    t.SetColor(Color.red);
            }
        }
    }
