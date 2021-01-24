        while (true)
        {
            while (HasReachedA == false)
            {
                yield return new WaitForEndOfFrame();
                transform.position = Vector2.Lerp(transform.position, pointA.position, 0.01f);
                if ((Mathf.Abs(Vector2.Distance(pointA.position, transform.position)) < 0.01f))
                {
                    HasReacedB = false;
                    HasReachedA = true;
                }
            }
            while (HasReacedB == false)
            {
                yield return new WaitForEndOfFrame();
                transform.position = Vector2.Lerp(transform.position, pointB.position, 0.01f);
                if ((Mathf.Abs(Vector2.Distance(pointB.position, transform.position)) < 0.01f))
                {
                    HasReacedB = true;
                    HasReachedA = false;
                }
            }
        }
    }
