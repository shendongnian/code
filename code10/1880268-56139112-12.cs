    cubePosition = Player.transform.position;
    if ((Input.GetKey(KeyCode.Mouse0) && cubeisClicked) && ((rb.velocity.x == 0f && rb.velocity.y == 0f)))
    {
        cubeisClicked2 = false;
        Plane cubePlane = new Plane(cam.transform.position - cubePosition, cubePosition);
        // reusing camRay
        // Determine if we are even hitting the plane
        float enter = 0.0f;
        if (cubePlane.Raycast(camRay, out enter))
        {
            cubeisClicked2 = true;
            fingerPosition  = camRay.GetPoint(enter);
            cubeFingerDiff = cubePosition - fingerPosition;
            ShotForce = new Vector3(cubeFingerDiff.x * shootingPowerX , cubeFingerDiff.y * shootingPowerY, cubeFingerDiff.z * shootingPowerX );
            if (cubeFingerDiff.magnitude>0.4f)
            {
                trajectoryDots.SetActive(true);
            }
            else
            {
                trajectoryDots.SetActive(false);
            }
            for (int dotNumber = 0; dotNumber < NumberOfDots; dotNumber++)
            {
                x1 = cubePosition.x + ShotForce.x * Time.fixedDeltaTime * (DotSeparation * dotNumber * dotShift);
                y1 = cubePosition.y + ShotForce.y * Time.fixedDeltaTime * (DotSeparation * dotNumber * dotShift) + (Physics.gravity.y / 2f * Time.fixedDeltaTime * Time.fixedDeltaTime * (DotSeparation * dotNumber + dotShift) * (DotSeparation * dotNumber + dotShift));
                z1 = cubePosition.z + ShotForce.z * Time.fixedDeltaTime * (DotSeparation * dotNumber * dotShift);
                Dots[dotNumber].transform.position = new Vector3(x1, y1, z1);
            }
        }         
    }
    if (Input.GetKeyUp(KeyCode.Mouse0) && cubeisClicked2)
    {
        cubeisClicked2 = false;
        trajectoryDots.SetActive(false);
        rb.velocity = new Vector3 (ShotForce.x, ShotForce.y, ShotForce.z);;
    }
