     public class CandleSpriteSwitch : MonoBehaviour
     {
        public Sprite CandleLit;
        public Sprite CandleUnlit;
        public SpriteRenderer render;
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("SmallFire"))
            {
                render.sprite = CandleLit;
            }
            else
            {
                render.sprite = CandleUnlit;
            }
        }
    }
