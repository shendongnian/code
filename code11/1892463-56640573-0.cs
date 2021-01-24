    public float moveSpeed = 3f;
    
    void Update ()
    {
  
    //Moves Left and right along x Axis              
    transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal")* moveSpeed);      
    }
