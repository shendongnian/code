    private bool IsGrounded()
        {
            if (myRigidbody.velocity.y <= 0)
            {
                foreach (Transform point in groundPoints)
                {
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatisGround);
                    for (int i = 0; i < colliders.Length; i++)
                    {
                        if (colliders[i].gameObject != gameObject)
                        {
                            return true;
                        }
                    }
                }
            }
                return false;
        }
