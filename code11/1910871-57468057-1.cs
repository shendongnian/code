    void MoveAim()
    {
        Vector3 gunRight = currentMovementDirection;
        Vector3 gunForward = Vector3.Cross(gunRight, Vector3.up);
        // Handle cases where the gun is pointing directly up or down
        if (gunForward == Vector3.zero)
        {
            gunForward = Vector3.forward;
        }
        Vector3 gunUp = Vector3.Cross(gunForward, gunRight);
        weapon.transform.rotation = Quaternion.LookRotation(gunForward, gunUp);
        //When player is standing still
        if (currentMovementDirection == Vector2.zero)
        {
            weapon.transform.rotation = Quaternion.Euler(0f, 0f, idleAngle);
        }
    }
