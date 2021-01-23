    class MyClass {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        public MyClass() {
            uint installCount = 1;
            PrivateFontCollection myFonts = new PrivateFontCollection();
            unsafe {
                fixed (byte* pFontData = Properties.Resources.MyFont) {
                    myFonts.AddMemoryFont((IntPtr)pFontData, Properties.Resources.MyFont.Length);
                    AddFontMemResourceEx((IntPtr)pFontData, (uint)Properties.Resources.MyFont.Length, IntPtr.Zero, ref installCount);
                }
            }
            myLabel.Font = new Font(myFonts.Families[0], 20f);
        }
    }
