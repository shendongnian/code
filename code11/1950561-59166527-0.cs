    void Awake()
    {
        float angle = 360f / (float)pieceCount;
        for (int layers = 0; layers < 8; layers++)
        {
            float angleOffset = (layers % 2) * 0.5f * angle;
            for (int i = 0; i < pieceCount; i++)
            {
                Quaternion rotation = Quaternion.AngleAxis(i * angle + angleOffset, Vector3.up);
                Vector3 direction = rotation  * Vector3.forward;
                Vector3 position = centerPos + (direction * radius);
                Instantiate(cylinder, position, rotation);
            }
            centerPos.y += .6f;
        }
    }
