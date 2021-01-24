    public class StarCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "White Ball" )
            { 
                ScoreScript.scoreValue += 1;
                
                // start the routine
                StartCoroutine(ChangeColor());
                gameObject.SetActive(false);
            }
        }
        private IEnumerator ChangeColor()
        {
            ScoreScript.score.color = Color.yellow;
            // yield says: return to main thread, renderer the frame
            // and continue from here in the next frame
            // WaitForseconds .. does exactly this
            yield return new WaitForseconds(0.2f);
            ScoreScript.score.color = Color.white;
        }
    }
