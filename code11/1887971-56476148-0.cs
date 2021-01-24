     public Transform PointA; public Transform PointB; public float NumberOfSegments = 3; public float AlongThePath = .25f;
    // Update is called once per frame
    void Start()
    {
        Create();
    }
    void Create()
    {
        StartCoroutine(StartSpheringOut());
    }
    IEnumerator StartSpheringOut()
    {
        NumberOfSegments += 1;// since we are skipping 1st placement since its the same as starting point we increase the number by 1 
        AlongThePath = 1 / (NumberOfSegments);//% along the path
        for (int i = 1; i < NumberOfSegments; i++)
        {
            yield return new WaitForSeconds(0.05f);
            Vector3 CreatPosition = PointA.position + (PointB.position - PointA.position) * (AlongThePath * i);
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = CreatPosition;
            sphere.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
    
