    public event Func<object, FormClosingAsyncEventArgs, Task> FormClosingAsync;
    public Form1()
    {
        InitializeComponent();
        this.InitFormClosingAsync(() => FormClosingAsync);
        this.FormClosingAsync += Window_FormClosingAsync_A;
        this.FormClosingAsync += Window_FormClosingAsync_B;
    }
