    public class Moneycount : MonoBehaviour
        {
            public Text scoreText;
            private Player money;
    
            public Moneycount(Player player)
            {
                money = player;
    
            }
            void Update()
            {
                scoreText.text = money.ToString();
            }
        }
