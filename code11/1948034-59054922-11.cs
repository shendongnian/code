        private void GoToPlatform(int index)
        {
            // Depends on your needs
            // You can either use a bool and ignore concurrent routines
            // or simply stop any running one
            StopAllCoroutines();
            StartCoroutine(MoveTo(platformProvider.platforms [index].position));
        }
    
        private IEnumerator MoveRoutine (Vector3 target)
        {
            while(!Mathf.Approximately(0, Vector3.Distance(transform.position, target)))
            {
                yield return new WaitForFixedUpdate();
    
                rigidbody.MovePositio (Vector3.MoveTowards(rigidbody.position, target, Time.deltaTime * moveSpeed);
            }
        }
    }
