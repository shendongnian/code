        using System;
        using System.Text;
        using System.Drawing;
        [DllImport("shell32.dll", EntryPoint = "#261", 
                   CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern void GetUserTilePath(
          string username, 
          UInt32 whatever, // 0x80000000
          StringBuilder picpath, int maxLength);
        public static string GetUserTilePath(string username)
        {   // username: use null for current user
            var sb = new StringBuilder(1000);
            GetUserTilePath(username, 0x80000000, sb, sb.Capacity);
            return sb.ToString();
        }
        public static Image GetUserTile(string username)
        {
            return Image.FromFile(GetUserTilePath(username));
        }
