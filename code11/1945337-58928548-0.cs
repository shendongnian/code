    // the OpenCV thread will add(push) entries
    // the Unity main thread will work on the entries
    private ConcurrentStack<Color32[]> stack = new ConcurrentStack<Color32[]>();
    public RawImage image;
    public Texture2D tex;
    bool stopFlag = false;
    void Start()
    {
        // Run MatToTexture2D in a thread
        Task.Run(() =>
        {
            while (!stopFlag)
            {
                MatToTexture2D();
            }
        }).ConfigureAwait(false);
        // Wherever you get your tex from
        tex = new Texture2D(...);
        // it should be enough to do this only once
        // the texture stays the same, you only update its content
        image.texture = tex;
    }
    // Runs in a thread!
    void MatToTexture2D()
    {
        // Do what you already have
        OpenCVInterop.GetRawImageBytes(pixelPtr);
        // However you convert the pixelPtr into Color32
        Color32[] pixel32 = GetColorArrayFromPtr(pixelPtr);
        // Now add this data to the stack
        stack.Push(pixel32);
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
