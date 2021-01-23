		ListView allCardsListView = new ListView();
		ListView selectedCardsListView = new ListView();
		List<Card> allCards = new List<Card>();
		List<Card> selectedCards = new List<Card>();
		public Form1()
		{
			InitializeComponent();
			
			foreach (Card selectedCard in selectedCards)
			{
				ListViewItem item = new ListViewItem(selectedCard.Name);
				item.Tag = selectedCard;
				selectedCardsListView.Items.Add(item);
			}
			foreach (Card card in allCards)
			{
				ListViewItem item = new ListViewItem(card.Name);
				item.Tag = card;
				allCardsListView.Items.Add(new ListViewItem(card.Name));
			}
			Button button = new Button();
			button.Click += new EventHandler(MoveSelectedClick);
		}
		void MoveSelectedClick(object sender, EventArgs e)
		{
			foreach (ListViewItem item in allCardsListView.SelectedItems)
			{
				Card card = (Card) item.Tag;
				//Do whatever with the card
			}
		}
