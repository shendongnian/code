    public IEnumerator moveObject() {
        float totalMovementTime = 5f; //the amount of time you want the movement to take
        float currentMovementTime = 0;//The amount of time that has passed
        while (Vector3.Distance(transform.localPosition, Destination) > 0) {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(Origin, Desination, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
