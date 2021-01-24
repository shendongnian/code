c#
private void Form1_DragEnter(object sender, DragEventArgs e)
{
    if (e.Data.GetDataPresent(DataFormats.FileDrop))
    {
        var file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        if (File.Exists(file))
        {
            e.Effect = DragDropEffects.Move;
            return;
        }
        //If you need to allow certain type of files:
        //if (Path.GetExtension(file).Equals(".srcExt", StringComparison.OrdinalIgnoreCase))
        //{
        //    e.Effect = DragDropEffects.Move;
        //    return;
        //}
    }
    e.Effect = DragDropEffects.None;
}
Then, handle the `DragDrop` event:
c#
private void Form1_DragDrop(object sender, DragEventArgs e)
{
    if (e.Effect == DragDropEffects.Move)
    {
        //according to your snippet:
        var srcFile = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        var destDir = @"The destination Directory";
        var destFile = string.Concat(
            Path.Combine(
            destDir,
            Path.GetFileNameWithoutExtension(srcFile)
            ),
            ".dat"
            );
        File.Move(srcFile, destFile);
    }
}
As for the the `Main` part, I believe @Jimi has already covered that perfectly in his comments, so let's _steal_ some from him to complete this post:
c#
[STAThread]
static void Main(string[] args)
{
    if(args.Length > 0 && File.Exists(args[0]))
    {
        var srcFile = args[0];
        var destDir = @"The destination Directory";
        var destFile = string.Concat(
            Path.Combine(
            destDir,
            Path.GetFileNameWithoutExtension(srcFile)
            ),
            ".dat"
            );
        File.Move(srcFile, destFile);
    }
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new Form1());            
}
Good luck.
