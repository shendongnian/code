    public float3 startingLocation;
    Transform place;
    public void SpwanTower(float xx, float yy, float zz, GameObject Brick)
    {
        Vector3 currPos = new Vector3(
            startingLocation.x,
            startingLocation.y,
            startingLocation.z
        );
        for (int i = 0; i < yy; i++)
        {
            for (int e = 0; e < xx; e++)
            {
                for (int o = 0; o < zz; o++)
                {
                    //you can change the plus sign to determine to what direction the tower will be built
                    currPos.x = startingLocation.x + e;
                    currPos.y = startingLocation.y + i;
                    currPos.z = startingLocation.z + o;
                    Instantiate(Brick, currPos, Quaternion.identity);
                }
            }
        }
    }
