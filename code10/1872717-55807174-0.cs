        public class AudioController : MonoBehaviour 
        {
    
            [SerializeField] public bool playSoundsAtColision = false; //you just shoud change the variable to public and default value to false or true
    
            private void OnCollisionEnter2D(Collision2D collision)
            {
                if (this.playSoundsAtColision)
                    Debug.Log("playSoundsAtColision = " + this.playSoundsAtColision + " by: " + gameObject.name, gameObject);
            }
        }
