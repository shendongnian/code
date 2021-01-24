    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class StarCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            ScoreScript.scoreValue += 1;
            StartCoroutine(ChangeColor());
        }
        private IEnumerator ChangeColor ()
        {
            if (other.gameObject.tag == "White Ball" )
            { 
                 ScoreScript.score.color = Color.yellow;
                 yield return new WaitForSeconds(0.2f);
                 ScoreScript.score.color = Color.white;
                 gameObject.SetActive(false);
            }
        }
    }
