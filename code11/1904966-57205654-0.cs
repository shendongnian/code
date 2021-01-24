    using UnityEngine;
    
    public class GameManager : MonoBehaviour
    {
        public GameObject[] figures;
    
        void Start(){
            foreach(GameObject figure in figures){
                //this is where you get all of their positions
                Debug.log(figure.transform.position)
            }
        }
        
    }
