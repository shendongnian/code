    public GameObject explosion;  //drag the particle system prefab here
    private void OnTriggerEnter2D(Collider2D enter)
    {
       if (enter.gameObject.tag.Equals("Player")) //when the enemy collides with the Player
       {
          HartCount.HartValue -= 1;
          GameObject particle = Instantiate (explosion, this.transform.position, Quaterion.identity);
          particle.GetComponent<ParticleSystem>().Play();
          Destroy(this.gameObject);
       }
    }
