    using UnityEngine;
    using UnityEngine.UI;
    
    namespace MyCompany.MyGame {
        public class Entry : MonoBehaviour {
            MyService myService;
    
            [SerializeField]
            Text playerName;
    
            void Awake () {
                myService = new MyService ();
            }
    
            void Start () {
                StartCoroutine (myService.GetUser ((User result) => {
                    Debug.Log (result);
                    playerName.text = result.login;
                }));
            }
        }
    }
