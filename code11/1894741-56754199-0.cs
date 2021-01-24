    {
        public Transform player;
        public Text scoreText;
    
        // Update is called once per frame
        void Update()
        {
            scoreText.text = player.position.z.ToString("0");
        }
    }
