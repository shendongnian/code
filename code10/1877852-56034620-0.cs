    void Update() {
        var yaw = Quaternion.AngleAxis(Input.GetAxis("Yaw"), transform.up);
        var pitch = Quaternion.AngleAxis(Input.GetAxis("Pitch"), transform.right);            
        var roll = Quaternion.AngleAxis(Input.GetAxis("Roll"), transform.forward);
        transform.rotation = transform.rotation * yaw * pitch * roll;
    }
