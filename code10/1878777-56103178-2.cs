    private void CheckGroundRays() {
            Ray middleRay = CreateEdgeCheckRay(0, 0);
            if (RayGrounded(middleRay)) {
                Vector3 inEdgeMovement = Vector3.zero;
                foreach(Ray ray in CreateSideRays()) {
                    if(RayGrounded(ray))
                        inEdgeMovement += (ray.origin - transform.position);
                }
                inEdgeMovement.y = 0;
                movement += inEdgeMovement;
            }
        }
