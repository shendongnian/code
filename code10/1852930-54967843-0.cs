    if (MovingCube.CurrentCube != null)
        MovingCube.CurrentCube.Stop();
    
    MovingCube.LastCube = MovingCube.CurrentCube;
    
    FindObjectOfType<CubeSpawner>().SpawnCube();
