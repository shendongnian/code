    var testData = new JsonData();
    // fill it with example values
    testData.eulerAngles = new List<Vector3>()
    {
        new Vector3(6.2255f, -15.8976f, -0.5881f)
    };
    testData.boxPoints = new List<Vector2>()
    {
        new Vector2(194.05965f, 194.15782f), 
        new Vector2(182.35829f, 189.05042f)
    };
    testData.landmarks = new List<Vector2Int>()
    {
        new Vector2Int(196, 225),
        new Vector2Int(197, 242),
        new Vector2Int(199, 258)
    }
    var result = JsonUtility.ToJson(testData);
