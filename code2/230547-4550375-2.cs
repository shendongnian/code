    public partial class CardContainer : UserControl {
        private List<Card> cards = new List<Card>();
        public CardContainer() {
            InitializeComponent();
            // Initialize cards here...
        }
        protected override void OnMouseUp(MouseEventArgs e) {
            foreach(Card card in cards) {
                card.CheckIfClicked(e);
            }
            base.OnMouseUp(e);
        }
    }
