    // Gyro X,Y,Z
    gx = Mathf.Deg2Rad * ((motionData[0] * 70000f + 500) / 1000f);
    gy = Mathf.Deg2Rad * ((motionData[1] * 70000f + 500) / 1000f);
    gz = Mathf.Deg2Rad * ((motionData[2] * 70000f + 500) / 1000f);
    // Acc X,Y,Z
    ax = (motionData[3] * 244f + 500) / 1000f;
    ay = (motionData[4] * 244f + 500) / 1000f;
    az = (motionData[5] * 244f + 500) / 1000f;
    Update(gx, gy, gz, ax, ay, az);
