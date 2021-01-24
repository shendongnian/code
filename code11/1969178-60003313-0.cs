    private Rigidbody miffyRigidbody;
    private FixedJoint BallFixedJoint;
    void OnTriggerEnter(Collider collider)
    {
        isColliding = true;
        if (collider.CompareTag("Player"))
        {
            miffyRigidbody = collider.attachedRigidbody;
        }
    }
    
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            miffyRigidbody = null;
        }
    }
    
    private void Update()
    {
        if(miffyRigidbody && Input.GetKeyDown(KeyCode.P))
        {
            if(!BallFixedJoint)
            {
                BallFixedJoint = Ball.GetComponent<FixedJoint>();
                if(!BallFixedJoint) BallFixedJoint = Ball.AddComponent<FixedJoint>();
            }
            BallFixedJoint.connectedBody = Miffy.GetComponent<Rigidbody>();
        }
        if(Input.GetKeyUp(KeyCode.P))
        {
            if(!BallFixedJoint)
            {
                BallFixedJoint = Ball.GetComponent<FixedJoint>();
                if(!BallFixedJoint) BallFixedJoint = Ball.AddComponent<FixedJoint>();
            }
            BallFixedJoint.connectedBody = null;
        }
    }
