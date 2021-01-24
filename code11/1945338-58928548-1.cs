    // the OpenCV thread will add(push) entries
    // the Unity main thread will work on the entries
    private ConcurrentStack<Color32[]> stack = new ConcurrentStack<Color32[]>();
    public RawImage image;
    public Texture2D tex;
    private Thread thread;
    void Start()
    {
        thread = new Thread(MatToTexture2D);
        thread.Start();
         // Wherever you get your tex from
         tex = new Texture2D(...);
        // it should be enough to do this only once
        // the texture stays the same, you only update its content
        image.texture = tex;
    }
    // Runs in a thread!
    void MatToTexture2D()
    {
        while(true)
        {
            // Do what you already have
            OpenCVInterop.GetRawImageBytes(pixelPtr);
            // However you convert the pixelPtr into Color32
            Color32[] pixel32 = GetColorArrayFromPtr(pixelPtr);
            // Now add this data to the stack
            stack.Push(pixel32);
        }
    }
    // Make sure to terminate he thread
    private void OnDestroy()
    {
        thread.Abort();
    }
    void Update()
    {
        // here in the main thread work the stack
        if (stack.TryPop(out var pixels32))
        {
            // Only use SetPixels and Apply when really needed
            tex.SetPixels32(pixels32);
            tex.Apply();
        }
        // Erase older data
        stack.Clear();
    }
