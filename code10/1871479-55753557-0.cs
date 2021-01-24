    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class PickUpReCharge : MonoBehaviour
    {
    
        public Animator anim;
        public Animator animc;
        public Animator anime;
        public GameObject neon;
        public GameObject chargesprite;
        public AudioSource recharge;
        public BoxCollider2D collision;
        public GameObject blackout;
        public AudioSource ambient;
        public AudioSource music;
    
        void Start()
    
        {
            anime.Play("Pickup", 0, 1f);
        }
    
        void Update()
    
        {
    
    
    
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
    
                neon.GetComponent<PlayerMovement>().enabled = true;
                chargesprite.GetComponent<SpriteRenderer>().enabled = false;
                collision.GetComponent<BoxCollider2D>().enabled = false;
                anim.SetBool("IsDead", false);
                anim.Rebind();
                animc.Rebind();
                anime.Rebind();
                recharge.Play();
                Destroy(gameObject, 3.0f);
    
          
    
                if (blackout.gameObject.activeSelf)
                {
                    ambient.Play();
                    music.Play();
                }
    
                blackout.gameObject.SetActive(false);
    
            }
        }
    }
