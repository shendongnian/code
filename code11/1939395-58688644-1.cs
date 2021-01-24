    // Move sprite bottom left to upper right.  It does not stop moving.
    // The Rigidbody2D gives the position for the cube.
    
    using UnityEngine;
    using System.Collections;
    
    public class Example : MonoBehaviour
    {
        public Texture2D tex;
    
        private Vector2 velocity;
        private Rigidbody2D rb2D;
        private Sprite mySprite;
        private SpriteRenderer sr;
    
        void Awake()
        {
            sr = gameObject.AddComponent<SpriteRenderer>();
            rb2D = gameObject.AddComponent<Rigidbody2D>();
        }
    
        void Start()
        {
            mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            velocity = new Vector2(1.75f, 1.1f);
            sr.color = new Color(0.9f, 0.9f, 0.0f, 1.0f);
    
            transform.position = new Vector3(-2.0f, -2.0f, 0.0f);
            sr.sprite = mySprite;
        }
    
        void FixedUpdate()
        {
            rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
        }
    }
