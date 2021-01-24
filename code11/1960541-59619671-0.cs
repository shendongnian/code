csharp
private void Saving()
{
    var hWnd = GetListViewHWnd(); // Desktop SysListView32 HWND
    IntPtr lParam = IntPtr.Zero;
    IntPtr pHil = SendMessage(hWnd, ListViewMessage.LVM_GETIMAGELIST, 0, ref lParam);
    var sHil = new SafeHIMAGELIST(pHil); // IMAGELIST of the ListView
    sHil.Interface.GetIconSize(out var cx, out var cy);
    var imageCount = sHil.Interface.GetImageCount(); // IImageList Interface
    var desktopHdc = new SafeHDC(GetDC(GetListViewHWnd()).DangerousGetHandle());
    var inMemoryHdc = CreateCompatibleDC(desktopHdc);
    
    for (int i = 0; i < imageCount; i++)
    {
        var inMemoryBmp = CreateCompatibleBitmap(desktopHdc, cx, cy);
        SelectObject(inMemoryHdc, inMemoryBmp);
        var ilDp = new IMAGELISTDRAWPARAMS(
            inMemoryHdc, 
            new RECT(0, 0, 0, 0), 
            i, 
            COLORREF.None,
            IMAGELISTDRAWFLAGS.ILD_NORMAL);
        
        sHil.Interface.Draw(ilDp);
        var bmpS = Imaging.CreateBitmapSourceFromHBitmap(
                inMemoryBmp.DangerousGetHandle(), 
                IntPtr.Zero,
                Int32Rect.Empty, 
                BitmapSizeOptions.FromEmptyOptions());
        
        using (var fs = File.OpenWrite(@"C:\Users\Julien\Desktop\Icons\" + i + ".png"))
        {
            BitmapEncoder enc = new PngBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(bmpS));
            enc.Save(fs);
        }
        inMemoryBmp.Dispose();
    }
    sHil.Dispose();
    desktopHdc.Dispose();
    inMemoryHdc.Dispose();
}
But as Jonathan Potter said it is **not** a good idea :
*A combination of `IShellItemImageFactory` and `SHCreateItemFromIDList` for example seem better.*
