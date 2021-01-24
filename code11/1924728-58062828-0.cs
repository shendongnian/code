    Vector3 CalculateRotationVector(){
        Vector3 RotationVector = Vector3.zero;
        if(Input.GetKey("up")){
            RotationVector += Vector3.right;
        }
        else if(Input.GetKey("down")){
            RotationVector -= Vector3.right;
        }else if(Input.GetKey("right")){
            RotationVector -= Vector3.right;
        }else if(Input.GetKey("left")){
            RotationVector += Vector3.right;
        }
        return RotationVector;
    }
