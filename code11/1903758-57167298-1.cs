    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using IWshRuntimeLibrary;
    namespace DragAndDropShortcut
    {
        public partial class DnDExample : Form
        {
            private readonly WshShell shell = new WshShell();
            public DnDExample()
            {
                InitializeComponent();
            }
            private void DnDExample_DragOver(object sender, DragEventArgs e)
            {
                // This checks that each file being dragged over is a .lnk file.
                // If it is not, it will show the invalid cursor thanks to some
                // e.Effect being set to none by default.
                bool dropEnabled = true;
                if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                {
                    if (e.Data.GetDataPresent(DataFormats.FileDrop, true) &&
                        e.Data.GetData(DataFormats.FileDrop, true) is string[] filePaths &&
                        filePaths.Any(filePath => Path.GetExtension(filePath)?.ToLowerInvariant() != ".lnk"))
                    {
                        dropEnabled = false;
                    }
                }
                else
                {
                    dropEnabled = false;
                }
                if (dropEnabled)
                {
                    // Set the effect to copy so we can drop the item
                    e.Effect = DragDropEffects.Copy;
                }
            }
            private void DnDExample_DragDrop(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                    e.Data.GetData(DataFormats.FileDrop, true) is string[] filePaths)
                {
                    // Print out the path and target of each shortcut file dropped on
                    foreach (string filePath in filePaths)
                    {
                        IWshShortcut link = (IWshShortcut)shell.CreateShortcut(filePath); //Link the interface to our shortcut
                        Console.WriteLine(filePath);
                        Console.WriteLine(link.TargetPath); //Show the target in a MessageBox using IWshShortcut
                        Console.WriteLine();
                    }
                }
            }
        }
    }
