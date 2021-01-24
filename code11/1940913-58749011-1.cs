    public class Moneycount : MonoBehaviour
    {
        public Text scoreText;
        private Player money;
        public Moneycount()
        {
            money = new Player();
        }
        void Update()
        {
            scoreText.text = money.ToString();
        }
    }
