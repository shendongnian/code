    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    public class MyClass
    {
        [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
        public string FilePath { get; set; }
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string FolderPath { get; set; }
    }
