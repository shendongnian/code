        using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class PickUpReCharge : MonoBehaviour
    {
    public Animator anim;
    public Animator animc;
    public Animator anime;
    void Start()
    {
        anime.Play("Pickup", 0, 0f);
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.Rebind();
            animc.Rebind();
            anime.Rebind();
            Destroy(gameObject, 0.3f);
        }
    }
    }
