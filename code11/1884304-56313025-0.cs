    using UnityEngine;
    using System.Linq;
    
    public class Four : MonoBehaviour
    {    
        public Sprite[] icons;
        void Start()
        {
            icons= Resources.LoadAll("met", typeof(Sprite)).Cast<Sprite>().ToArray();
        }
    }
