    [SerializeField] GameObject imgs; // unity now warns about this, its safe to ignore. I often set things to null just to shut it up
       public void ResetScreen()
        {
            for (int a = 0; a <transform.childCount; a++)
            {
                transform.GetChild(a).gameObject.SetActive(false);
            }
        }
    
        public void RandomGenerate()
        {
    // if you supply random range with ints, it picks ints, between first and 1 less than last which is what you wanted.
            if (imgs.Length>0)
               imgs[Random.Range(0, imgs.Length)].SetActive(true); 
    
        }
     
