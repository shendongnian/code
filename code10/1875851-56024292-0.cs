    private void CheckSameRotation() {
        if (lastRotation != currentRotation || movement == Vector3.zero) {
                sameRotationTime = 0;
                lastRotation = currentRotation;
        }
        else {
            sameRotationTime += Time.deltaTime;
        }
    }
