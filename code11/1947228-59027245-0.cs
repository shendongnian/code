    using System.Linq;
    public List<GameObject> cardsToSpawn;
    public List<Transform> cardPositions = new List<Transform>();
    
    void Awake()
    {
        // First make sure both lists have the same length
        if(cardsToSpawn.Count != cardPositions.Count) 
        {
            Debug.LogError("List length are different! Make sure you have the same amount of elements in both lists!");
            return;
        }
    
        // get the cards in randomized order
        Random rnd = new Random();
        var shuffledCards = cardsToSpawn.OrderBy(c => rnd.Next()).ToArray();    
    
        for (int i = 0; i < shuffledCards.Length; i++) 
        {
            // since the cards are already shuffled you can simply iterate
            // over this array in order now
            var card = shuffledCards[i];
            var position = cardPositions[i];
    
            Instantiate(card, position, transform.rotation);
        }
    }
