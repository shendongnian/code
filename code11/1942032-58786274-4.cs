    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.InteropServices;
    [DllImport("user32.dll")]
    private static extern int GetWindowRect(IntPtr hwnd, out Rectangle rect);
    Rectangle rect;
    GetWindowRect(Process.GetCurrentProcess().MainWindowHandle, out rect);
    Console.WriteLine($"Console window location: {rect.X}x{rect.Y}");
    Console.WriteLine($"Console window resolution: {rect.Width}x{rect.Height}");
