    Vector3[] positions = new Vector3[] {
        new Vector3(Screen.Width/2f, 0f, 1f),
        new Vector3(Screen.Width, 0f, 1f)
    };
    int counter = 0;
    void Update() {
        if (Input.GetMouseDown(0)) {
            Vector3 pos = positions[Mathf.Min(positions.Length-1, counter++)];
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
            myCube.transform.position = worldPos;
        }
    }
