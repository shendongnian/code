    GameObject GhostApparition;
        // Use this for initialization
        void OnTriggerEnter (Collider other)
        {
            if (other.tag == "Player") ;
            {
                 GhostApparition.SetActive(true);
            }
        }
    
        void OnTriggerExit (Collider other)
        {
            if (other.tag == "Player") ;
            {
                 GhostApparition.SetActive(false);
            }
        }
