     if (!accelerated)
        {
            Vector3 playerPosition = gameObject.transform.position;
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == 0)
                {
                    playerPosition = Camera.main.WorldToScreenPoint(playerPosition);
                    Vector2 touchPosition = touch.position;
                    if (touchPosition.x -15 >= playerPosition.x)
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * speed);
                    }
                    else if (touchPosition.x + 15 <= playerPosition.x)
                    {
                        transform.Translate(-Vector3.right * Time.deltaTime * speed);
                    }
                }
                if (touch.fingerId == 1)
                {
                    Accelerate();
                }
            }
        }
