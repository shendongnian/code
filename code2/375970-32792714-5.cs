    [Test]
    public void When_WindowIsMaximized_PaddingBordersShouldBeExcludedFromArea()
    {
        // Top, Left are -8 when window is maximized but should be 0,0
        // http://blogs.msdn.com/b/oldnewthing/archive/2012/03/26/10287385.aspx
        INativeMethods nativeMock = MockRepository.GenerateStub<INativeMethods>();
        var windowRectangle = new Rect() {Left = -8, Top = -8, Bottom = 1216, Right = 1936};
        var expectedScreenBounds = new Rect() {Left = 0, Top = 0, Bottom = 1200, Right = 1920};
        _displayInfo.Stub(_ => _.GetScreenBoundsFromWindow(windowRectangle.ToRectangle())).Return(expectedScreenBounds.ToRectangle());
        var hwnd = RandomNativeHandle();
        StubForMaximizedWindowState(nativeMock, hwnd);
        StubForDwmRectangle(nativeMock, hwnd, windowRectangle);
        WindowCoverageReader target = GetTarget(nativeMock);
        var window = target.GetWindowFromHandle(hwnd);
        Assert.AreEqual(WindowState.Maximized, window.WindowState);
        Assert.AreEqual(expectedScreenBounds.ToRectangle(), window.Area);
    }
    private void StubForDwmRectangle(INativeMethods nativeMock, IntPtr hwnd, Rect rectToReturnFromWinApi)
    {
        var sizeOf = Marshal.SizeOf(rect);
        var rect = new Rect();
        nativeMock.Stub(_ =>
        {
            _.DwmGetWindowAttribute(
                hwnd, 
                (int)DwmWindowAttribute.DwmwaExtendedFrameBounds,
                out rect,  // called with zeroed object
                sizeOf);
        }).OutRef(rectToReturnFromWinApi).Return(0);
    }
    private IntPtr RandomNativeHandle()
    {
        return new IntPtr(_random.Next());
    }
    private void StubForMaximizedWindowState(INativeMethods nativeMock, IntPtr hwnd)
    {
        var maximizedFlag = 3;
        WindowPlacement pointerToWindowPlacement = new WindowPlacement() {ShowCmd = maximizedFlag};
        nativeMock.Stub(_ => { _.GetWindowPlacement(Arg<IntPtr>.Is.Equal(hwnd), ref Arg<WindowPlacement>.Ref(new Anything(), pointerToWindowPlacement).Dummy); }).Return(true);
    }
