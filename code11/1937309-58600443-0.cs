    public Transform playerObject;
`
    //Controls the pitch of the camera where it rotates
    //in X axis
    public float pitchOffset = 0;
    //Controls the yaw of the camera where it rotates
    //in Y axis
    public float yawOffset = 0;
    public float distanceFromObject = 6f;
    void Update()
    {
        //Creation of the look offset relative to the
        //Observable position
        Vector3 lookOffset = playerObject.position;
        lookOffset.y += pitchOffset;
        lookOffset.x += yawOffset;
        Vector3 lookOnObject = playerObject.position - transform.position;
        //Replaced playerObject.position with lookOffset
        lookOnObject = lookOffset - transform.position;
        transform.forward = lookOnObject.normalized;
        Vector3 playerLastPosition;
        //Replaced playerObject.position with lookOffset
        playerLastPosition = lookOffset - lookOnObject.normalized * distanceFromObject;
        playerLastPosition.y = playerObject.position.y + distanceFromObject / 2;
        transform.position = playerLastPosition;
    }
}
