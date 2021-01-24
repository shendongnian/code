    void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Present")
            {
                Destroy(gameObject); // this is destroying the current gameobject i.e. the player
                count = count - 1;
                SetCountText();
            }
        }
