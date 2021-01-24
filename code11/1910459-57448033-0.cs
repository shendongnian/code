    public ParticleSystem explosion;
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("Player"))
        {
            HartCount.HartValue -= 1;
            gameObject.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject);
        }
    }
