        public Vector3 hiddenRotation;
    void Start()
    {
        hiddenRotation = this.transform.rotation.eulerAngles;
    }
    void Update()
    {
        float sensitivity = 5.0f;
        //Get rotation vector
        Vector3 rot = new Vector3(0, -Input.GetAxis("Mouse X"), 0) * sensitivity;
        //Add rotation to hidden internal rotation
        hiddenRotation += rot;
        //Specify speed at which the cube rotates.
        float speed = 50.0f;
        float step = speed * Time.deltaTime;
        //Set new rotation (changing this function may allow for smoother motion, like lower step as it approaches the new rotation
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(hiddenRotation), step);
    }
