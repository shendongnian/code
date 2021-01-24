    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class StarCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("White Ball"))
            { 
                ScoreScript.scoreValue += 1;
                StartCoroutine(ChangeColor(other));
            }
        }
        private IEnumerator ChangeColor (GameObject other)
        {
             ScoreScript.score.color = Color.yellow;
             yield return new WaitForSeconds(0.2f);
             ScoreScript.score.color = Color.white;
             gameObject.SetActive(false);
        }
    }
