    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    [System.Serializable]
    public class GameMain : MonoBehaviour
    {   private static GameMain _gameMain;
        public static GameMain Instance {get {return _gameMain;}}
        void Awake()
        {
            _gameMain = this;
        }
    
        // getter: is falling allowed for the cube
        public bool getFalling(){
            return true;
        }
    }
