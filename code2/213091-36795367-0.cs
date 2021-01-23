    class IconChanger
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int UpdateResource(IntPtr hUpdate, uint lpType, uint lpName, ushort wLanguage, byte[] lpData, uint cbData);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr BeginUpdateResource(string pFileName,[MarshalAs(UnmanagedType.Bool)]bool bDeleteExistingResources);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);
        public enum ICResult
        {
            Success,
            FailBegin,
            FailUpdate,
            FailEnd
        }
        const uint RT_ICON = 3;
        const uint RT_GROUP_ICON = 14;
        public ICResult ChangeIcon(string exeFilePath, string iconFilePath)
        {
            // Load executable
            IntPtr handleExe = BeginUpdateResource(exeFilePath, false);
            if (handleExe == null) return ICResult.FailBegin;
            // Get the icon data
            byte[] data = null;
            using (var fs = new FileStream(iconFilePath, FileMode.Open, FileAccess.Read))
            using (var input = new BinaryReader(fs))
            {
                input.ReadBytes(22); // skip the first bytes; assume that there is only one icon in the file and only one is replaced
                data = input.ReadBytes((int)input.BaseStream.Length);
            }
            // Replace the icon
            var ret = UpdateResource(handleExe, RT_ICON, 1, 1043, data, (uint)data.Length);
            if (ret==1)
            {
                if (EndUpdateResource(handleExe, false))
                    return ICResult.Success;
                else
                    return ICResult.FailEnd;
            }
            else
                return ICResult.FailUpdate;
        }
    }
