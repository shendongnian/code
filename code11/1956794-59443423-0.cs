    List<Transform> context = new List<Transform>();
    
        IEnumerator Flock()
        {
            context.Clear(); // if there are 1000s this could be costly
            Collider[] NearbyBoids = Physics.OverlapSphere(BoidVec, VisionRange, BoidMask, QueryTriggerInteraction.Collide);
        
            foreach (Collider Boid in NearbyBoids)
            {
                context.Add(NearbyBoids.transform);
            }
            yield return null;
        }
