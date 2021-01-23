<pre>
    // C# Definition for Delphi 2-D array
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct TFrames
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=(MAX_BOWLERS)*(gMAX_FRAMES+1))]
        private TFrame[] row;
        public TFrame this[int iBowler, int iFrame]
        {
            get
            {
                int ioffset = (iBowler * (gMAX_FRAMES+1)) + iFrame;
                return row[ioffset];
            }
        }
    }</pre></code>
<pre>
   // C# client example
    public static string ConvertSplitToString(TgameRec currentGame, int iBowler)
    {
        StringBuilder sb = new StringBuilder();
        TFrames frames = currentGame.frames;
        for (int iFrame = 0; iFrame < 10; iFrame++)
        {
            if (frames[iBowler, iFrame].fSplit != 0)
                sb.Append('.');
            else 
                sb.Append(' ');
        }
        return sb.ToString ();
    }</pre></code>
