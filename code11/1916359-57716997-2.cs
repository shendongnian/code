     private void OnTriggerEnter(Collider collider)
        {
            if (collider == playerCollider)
            {
                audioSource.PlayOneShot(splashInWater);
            }
        }
