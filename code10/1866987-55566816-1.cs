    virtual protected void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Zombie"))
        {
            Destroy(gameObject);//destroy bullet
            // Note you then should use GetComponentInParent here
            // since your colliders are now on child objects
            Zombie zombie = collider2D.gameObject.GetComponentInParent<Zombie>();
            var bodyPart = collider2D.GetComponent<BodyPart>();
            switch(bodyPart.Type)
            {
                case BodyPartType.Head:
                    zombie.HeadShot(demage);//headshot
                    break;
                // you now could differ between more types here
                default:
                    zombie.BulletHit(demage);//normal hit
                    break;
            }
        }
    }
