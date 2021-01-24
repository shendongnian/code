    using UnityEngine;
    using System.Collections;
     
    public class MouseMovement : MonoBehaviour 
    {
        public float speed = 10f;
        bool isplayermove = false;
        // Use this for initialization
        private void Start () 
        {
            Vector3 playerpos = transform.position;
        }
         
        // Update is called once per frame
        private void Update () 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                is moveplayer = true;
            }
            if(ismoveplayer)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(input.mousepos.x,input.mousepos.y,input.mousepos.z);
                transform.position = Vector3.MoveTowards(transform.position,new Vector3(mousepos.x,transform.position.y,mousepos.z),speed * time.deltatime);
                if(transform.position == mousepos)
                {
                    ismoveplayer = false;  
                }  
            }
        }
    }
