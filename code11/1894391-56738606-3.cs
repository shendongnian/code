    public GameObject A;
    public GameObject B;
    public int amount;
    public void PlaceSpheres(Vector3 posA, Vector3 posB, int numberOfObjects)
    {
        var radius = Vector3.Distance(posA, posB) / 2f;
        var centerPos = (posA + posB) / 2f;
        var centerDirection = Quaternion.LookRotation((posB - posA).normalized);
        for (var i = 0; i < numberOfObjects; i++)
        {
            // Max angle is 180°
            //          |       don't place the first object exactly on posA but on the next offset
            //          |          |             don't place the last object on posB but end one offset before
            //          |          |                        |
            //          V          V                        V
            var angle = 180f * (i + 1) / (numberOfObjects + 1f);
            var x = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            var z = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            var pos = new Vector3(x, 0, z);
            // Rotate the pos vector according to the centerDirection
            pos = centerDirection * pos;
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = centerPos + pos;
            sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
    }
