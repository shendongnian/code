     Transform coin = GameObject.Find("Coins").transform;
         void Start()
         {
             for (int j = 0; j < coin.childCount; j++)
             {
                 coin.GetChild(j).gameObject.SetActive(false);
             }
         }
    void Update()
    {
        if (tutorialcoins)
        {
            for (int j = 0; j < coin.childCount; j++)
                 {
                     coin.GetChild(j).gameObject.SetActive(false);
                 }
        }
    
     }
