    // the OpenCV thread will add(push) entries
    // the Unity main thread will work on the entries
    private ConcurrentStack<Color32[]> stack = new ConcurrentStack<Color32[]>();
    public RawImage image;
    public Texture2D tex;
    private Thread thread;
    void Start()
    {
        // Wherever you get your tex from
        tex = new Texture2D(...);
        // it should be enough to do this only once
        // the texture stays the same, you only update its content
        image.texture = tex;
    }
    // do things in OnEnable so everytime the object gets enabled start the thread
    void OnEnable()
    {
        if(thread != null)
        {
            thread.Abort();
        }
        thread = new Thread(MatToTexture2D);
        thread.Start();
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
    // Make sure to terminate the thread everytime this object gets disabled
    private void OnDisable()
    {
        if(thread == null) return;
        
        thread.Abort();
        thread = null;
    }
    // Runs in a thread!
    void MatToTexture2D()
    {
        while(true)
        {
            try
            {
                // Do what you already have
                OpenCVInterop.GetRawImageBytes(pixelPtr);
                // However you convert the pixelPtr into Color32
                Color32[] pixel32 = GetColorArrayFromPtr(pixelPtr);
                // Now add this data to the stack
                stack.Push(pixel32);
            }
            catch (ThreadAbortException ex) 
            { 
                // This exception is thrown when calling Abort on the thread
                // -> ignore the exception since it is produced on purpose
            } 
        }
    }
