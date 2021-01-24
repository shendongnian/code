    using System;
    using Microsoft.WindowsAPICodePack.Dialogs;
    namespace DialogTest
    {
        class Program
        {
            [STAThread]
            public static void Main(string[] args)
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = "C:\\Users";
                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result == CommonFileDialogResult.Ok)
                {
                    //Do Stuff
                }
            }
        }
    }
