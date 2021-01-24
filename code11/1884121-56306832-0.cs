    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class Test : MonoBehaviour
    {
        public int hitPoint = 3;
        public GameObject explosion;
        public GameObject heart;
        [Range(0f, 1f)]
        public float percentage;
        float randNum;
        public float fallSpeed = 8.0f;
        public Sprite OneHits;
        public Sprite TwoHits;
        public Sprite ThreeHits;
        public Text ScoreText;
        public static int points;
        GameObject ball;
        void Start()
        {
            ball = GameObject.FindGameObjectWithTag("ball");
        }
        void Update()
        {
            ScoreText.text = "Score " + points;
            randNum = Random.Range(0f, 1f);
            if (hitPoint == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = OneHits;
            }
            if (hitPoint == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = TwoHits;
            }
            if (hitPoint == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = ThreeHits;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("ball"))
            {
                ball = collision.gameObject;
                hitPoint--;
                points++;
                if (hitPoint <= 0)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                    if (randNum < percentage)
                    {
                        Instantiate(heart, transform.position, transform.rotation);
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
