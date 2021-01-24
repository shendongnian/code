c#
public partial class Form1 : Form
{
    //private readonly string _tempFileName = Path.GetTempFileName();
    private readonly string _tempFileName = "temp.bin";
    private const long _tempFileSize = 1024 * 1024 * 1024; // 1GB
    public Form1()
    {
        InitializeComponent();
    }
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        if (Path.GetDirectoryName(_tempFileName).Equals(Path.GetTempPath(), StringComparison.OrdinalIgnoreCase))
        {
            File.Delete(_tempFileName);
        }
    }
    private void _InitTempFile(IProgress<long> progress)
    {
        Random random = new Random();
        byte[] buffer = new byte[4096];
        long bytesToWrite = _tempFileSize;
        using (Stream stream = File.OpenWrite(_tempFileName))
        {
            while (bytesToWrite > 0)
            {
                int writeByteCount = (int)Math.Min(buffer.Length, bytesToWrite);
                random.NextBytes(buffer);
                stream.Write(buffer, 0, writeByteCount);
                bytesToWrite -= writeByteCount;
                progress.Report(_tempFileSize - bytesToWrite);
            }
        }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        int workerThreadCount, iocpThreadCount;
        int workerMax, iocpMax, workerMin, iocpMin;
        ThreadPool.GetAvailableThreads(out workerThreadCount, out iocpThreadCount);
        ThreadPool.GetMaxThreads(out workerMax, out iocpMax);
        ThreadPool.GetMinThreads(out workerMin, out iocpMin);
        label3.Text = $"IOCP: active - {workerMax - workerThreadCount}, {iocpMax - iocpThreadCount}; min - {workerMin}, {iocpMin}";
        label1.Text = DateTime.Now.ToString("hh:MM:ss");
    }
    private async void Form1_Load(object sender, EventArgs e)
    {
        if (!File.Exists(_tempFileName) || new FileInfo(_tempFileName).Length == 0)
        {
            IProgress<long> progress = new Progress<long>(cb => progressBar1.Value = (int)(cb * 100 / _tempFileSize));
            await Task.Run(() => _InitTempFile(progress));
        }
        button1.Enabled = true;
    }
    private async void button1_Click(object sender, EventArgs e)
    {
        label2.Text = "Status:";
        label2.Update();
        // 0x20000000 is the only non-named value allowed
        FileOptions options = checkBox1.Checked ?
            FileOptions.Asynchronous | (checkBox2.Checked ? (FileOptions)0x20000000 : FileOptions.None) :
            FileOptions.None;
        using (Stream stream = new FileStream(_tempFileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, options /* useAsync: true */))
        {
            await _ReadAsync(stream, (int)stream.Length);
        }
        label2.Text = "Status: done reading file";
    }
    private async Task _ReadAsync(Stream stream, int bufferSize)
    {
        byte[] data = new byte[bufferSize];
        label2.Text = $"Status: reading {data.Length} bytes from file";
        while (await stream.ReadAsync(data, 0, data.Length) > 0)
        {
            // empty loop
        }
    }
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        checkBox2.Enabled = checkBox1.Checked;
    }
}
#region Windows Form Designer generated code
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private void InitializeComponent()
{
    this.components = new System.ComponentModel.Container();
    this.button1 = new System.Windows.Forms.Button();
    this.progressBar1 = new System.Windows.Forms.ProgressBar();
    this.label1 = new System.Windows.Forms.Label();
    this.timer1 = new System.Windows.Forms.Timer(this.components);
    this.label2 = new System.Windows.Forms.Label();
    this.label3 = new System.Windows.Forms.Label();
    this.checkBox1 = new System.Windows.Forms.CheckBox();
    this.checkBox2 = new System.Windows.Forms.CheckBox();
    this.SuspendLayout();
    // 
    // button1
    // 
    this.button1.Enabled = false;
    this.button1.Location = new System.Drawing.Point(13, 13);
    this.button1.Name = "button1";
    this.button1.Size = new System.Drawing.Size(162, 62);
    this.button1.TabIndex = 0;
    this.button1.Text = "button1";
    this.button1.UseVisualStyleBackColor = true;
    this.button1.Click += new System.EventHandler(this.button1_Click);
    // 
    // progressBar1
    // 
    this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
    | System.Windows.Forms.AnchorStyles.Right)));
    this.progressBar1.Location = new System.Drawing.Point(13, 390);
    this.progressBar1.Name = "progressBar1";
    this.progressBar1.Size = new System.Drawing.Size(775, 48);
    this.progressBar1.TabIndex = 1;
    // 
    // label1
    // 
    this.label1.AutoSize = true;
    this.label1.Location = new System.Drawing.Point(13, 352);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(93, 32);
    this.label1.TabIndex = 2;
    this.label1.Text = "label1";
    // 
    // timer1
    // 
    this.timer1.Enabled = true;
    this.timer1.Interval = 250;
    this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
    // 
    // label2
    // 
    this.label2.AutoSize = true;
    this.label2.Location = new System.Drawing.Point(13, 317);
    this.label2.Name = "label2";
    this.label2.Size = new System.Drawing.Size(111, 32);
    this.label2.TabIndex = 3;
    this.label2.Text = "Status: ";
    // 
    // label3
    // 
    this.label3.AutoSize = true;
    this.label3.Location = new System.Drawing.Point(13, 282);
    this.label3.Name = "label3";
    this.label3.Size = new System.Drawing.Size(93, 32);
    this.label3.TabIndex = 4;
    this.label3.Text = "label3";
    // 
    // checkBox1
    // 
    this.checkBox1.AutoSize = true;
    this.checkBox1.Location = new System.Drawing.Point(13, 82);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new System.Drawing.Size(176, 36);
    this.checkBox1.TabIndex = 5;
    this.checkBox1.Text = "useAsync";
    this.checkBox1.UseVisualStyleBackColor = true;
    this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
    // 
    // checkBox2
    // 
    this.checkBox2.AutoSize = true;
    this.checkBox2.Enabled = false;
    this.checkBox2.Location = new System.Drawing.Point(13, 125);
    this.checkBox2.Name = "checkBox2";
    this.checkBox2.Size = new System.Drawing.Size(228, 36);
    this.checkBox2.TabIndex = 6;
    this.checkBox2.Text = "disable cache";
    this.checkBox2.UseVisualStyleBackColor = true;
    // 
    // Form1
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(800, 450);
    this.Controls.Add(this.checkBox2);
    this.Controls.Add(this.checkBox1);
    this.Controls.Add(this.label3);
    this.Controls.Add(this.label2);
    this.Controls.Add(this.label1);
    this.Controls.Add(this.progressBar1);
    this.Controls.Add(this.button1);
    this.Name = "Form1";
    this.Text = "Form1";
    this.Load += new System.EventHandler(this.Form1_Load);
    this.ResumeLayout(false);
    this.PerformLayout();
}
#endregion
private System.Windows.Forms.Button button1;
private System.Windows.Forms.ProgressBar progressBar1;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Timer timer1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.CheckBox checkBox1;
private System.Windows.Forms.CheckBox checkBox2;
To address the follow-up questions posted as comments:
> 1. what is differences between useAsync and FileOption.Asyncronous
None. The overload with the `bool` parameter is just there for convenience. It does exactly the same thing.
> 2. when should i useAsync : false with Asyncronous methods and useAsync : true?
When you want the added performance of overlapped I/O, you should specify `useAsync: true`.
> 3. " If you use that flag along with the FileOptions.Asynchronous value, you will find that ReadAsync() will in fact complete asynchronously. " , i think that Asyncronous dont block UI but when i use this flag UI still block untill ReadAsync finish
That's not really a question, but&hellip;
It seems like you are disputing my statement that including the `FILE_FLAG_NO_BUFFERING` in the `FileOptions` parameter will cause `ReadAsync()` to complete asynchronously (which it would do by disabling the use of the file system cache).
I can't tell you what happens on your computer. Generally, I'd expect it to be the same as on my computer, but there are no guarantees. What I _can_ tell you is that disabling caching, by using `FILE_FLAG_NO_BUFFERING`, is 100% reliable in my tests for causing `ReadAsync()` to complete asynchronously.
It is important to note that the actual _meaning_ of the flag is not _"cause `ReadAsync()` to complete asynchronously"_. That's simply the _side-effect_ I observe of using that flag. Caching is not the only condition that would cause `ReadAsync()` to complete synchronously, so it's entirely possible that even when using that flag, you would still see `ReadAsync()` complete synchronously.
Regardless, I think that's all of no real concern. I don't think that using the `FILE_FLAG_NO_BUFFERING` is actually a good idea. I have included that in this discussion _only_ as a way to explore the reason why `ReadAsync()` completes synchronously. I am _not_ suggesting that it's a good idea in general to use that flag.
You should in fact generally prefer the increased performance of overlapped I/O, and so should use `useAsync: true` without disabling caching (because disabling caching will harm performance). But you should combine that with _also_ doing the I/O in a worker thread (e.g. with `Task.Run()`), at least when you are dealing with very large files, so that you don't block the UI.
This may in some cases result in _slightly_ less overall throughput, simply because of the thread context switching. But that switching is very cheap compared to file I/O itself and as long as the UI remains responsive, is not something a user will even notice.
  [1]: https://support.microsoft.com/en-us/help/156932/asynchronous-disk-i-o-appears-as-synchronous-on-windows
