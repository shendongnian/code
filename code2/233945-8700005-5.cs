    [Guid("3050f669-98b5-11cf-bb82-00aa00bdce0b"),
             InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
             ComVisible(true),
             ComImport]
        interface IHTMLElementRender2
        {
            void DrawToDC([In] IntPtr hDC);
            void SetDocumentPrinter([In, MarshalAs(UnmanagedType.BStr)] string bstrPrinterName, [In] IntPtr hDC);
        };
