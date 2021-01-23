      [DllImport("ole32.dll")]
      private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);
      [DllImport("ole32.dll")]
      private static extern void GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
      internal static DTE2 GetCurrent()
      {
         //rot entry for visual studio running under current process.
         string rotEntry = String.Format("!VisualStudio.DTE.10.0:{0}", Process.GetCurrentProcess().Id);
         IRunningObjectTable rot;
         GetRunningObjectTable(0, out rot);
         IEnumMoniker enumMoniker;
         rot.EnumRunning(out enumMoniker);
         enumMoniker.Reset();
         IntPtr fetched = IntPtr.Zero;
         IMoniker[] moniker = new IMoniker[1];
         while (enumMoniker.Next(1, moniker, fetched) == 0)
         {
            IBindCtx bindCtx;
            CreateBindCtx(0, out bindCtx);
            string displayName;
            moniker[0].GetDisplayName(bindCtx, null, out displayName);
            if (displayName == rotEntry)
            {
               object comObject;
               rot.GetObject(moniker[0], out comObject);
               return (EnvDTE80.DTE2)comObject;
            }
         }
         return null;
      }
