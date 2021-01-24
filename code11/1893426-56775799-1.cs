    // Gyro X,Y,Z
    gx = Mathf.Deg2Rad * (motionData[0] * 70000f + 500) / 1000000;
    gy = Mathf.Deg2Rad * (motionData[1] * 70000f + 500) / 1000000;
    gz = Mathf.Deg2Rad * (motionData[2] * 70000f + 500) / 1000000;
    // Acc X,Y,Z
    ax = (motionData[3] * 244f + 500) / 1000000;
    ay = (motionData[4] * 244f + 500) / 1000000;
    az = (motionData[5] * 244f + 500) / 1000000;
    Update(gx, gy, gz, ax, ay, az);
