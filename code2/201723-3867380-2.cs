    //Mmmm...Full House
    List<Card> inHandCards = new List<Card> { ...Cards...}; //2 Kings?
    List<Card> faceDownCards = new List<Card> { ...Cards...}; 
    List<Card> faceUpCards = new List<Card> { ...Cards...};  //3 4s?
    Mock<IHand> hand = new Mock<IHand>();
    hand.SetupGet(h => FaceDownCards).Returns(faceDownCards);
    hand.SetupGet(h => FaceUpCards).Returns(faceUpCards);
    hand.SetupGet(h => InHandCards).Returns(inHandCards);
    Mock<IPlayer> player = new Mock<IPlayer>();
    player.SetupGet(p => p.Hand).Returns(hand);
    //Use player.Object in Game
