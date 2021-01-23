Player player = new Player(3);
player.Cards.Add(CardType.Diamond);
player.Cards.Add(CardType.Club);
player.Cards.Add(CardType.Spade);
Dictionary<CardType, PictureBox> dictionary = new Dictionary<CardType, PictureBox>();
dictionary.Add(CardType.Diamond, pb_diamonds);
dictionary.Add(CardType.Spade, pb_spades);
dictionary.Add(CardType.Club, pb_clubs);
dictionary.Add(CardType.Heart, pb_hearts);
