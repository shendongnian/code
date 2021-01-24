       void OnCollisionEnter(Collision other)
            {
                if (other.gameObject.CompareTag("Present"))
                {
                    Destroy(other.gameObject); // this is destroying the other gameobject
                    count = count - 1;
                    SetCountText();
                }
            }
