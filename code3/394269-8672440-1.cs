    private const string SDL = "SDL.dll";
    [DllImport(SDL, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    public static extern IntPtr SDL_LoadBMP_RW(IntPtr src, int freesrc);
    [DllImport(SDL, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    public static extern IntPtr SDL_RWFromFile(string file, string mode);
    public static IntPtr SDL_LoadBMP(string file)
    {
        return SDL_LoadBMP_RW(SDL_RWFromFile(file, "rb"), 1);
    }
