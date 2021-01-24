    public class CandleSpriteSwitch : MonoBehaviour
    {
        public Sprite candleLit;
        public Sprite candleUnlit;
        public SpriteRenderer render;
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("SmallFire"))
            {
                render.sprite = candleLit;
            }
            else
            {
                render.sprite = candleUnlit;
            }
        }
    }
