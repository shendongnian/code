    public partial class Form1 : Form
        {
            updateUI _updateGUI;
            CancellationToken _cancelToken;
            PauseTokenSource _pauseTokeSource;
            public Form1()
            {
                InitializeComponent();
            }
    
          
            delegate void updateUI(dynamic value);
    
            private void btnStartAsync_Click(object sender, EventArgs e)
            {
                _pauseTokeSource = new PauseTokenSource();
                _cancelToken = default(CancellationToken);
    
                _pauseTokeSource.onPause -= _pauseTokeSource_onPause;
                _pauseTokeSource.onPause += _pauseTokeSource_onPause;
    
                Task t = new Task(() => { LongRunning(_pauseTokeSource); }, _cancelToken);
                t.Start();
    
            }
    
            private void _pauseTokeSource_onPause(object sender, PauseEventArgs e)
            {
                var message = string.Format("Task {0} at {1}", e.Paused ? "Paused" : "Resumed", DateTime.Now.ToString());
                this.Invoke(_updateGUI, message);
            }
    
            private async void LongRunning(PauseTokenSource pause)
            {
                _updateGUI = new updateUI(SetUI);
                for (int i = 0; i < 20; i++)
                {
    
                    await pause.WaitWhilePausedAsync();
    
                    Thread.Sleep(500);
                    this.Invoke(_updateGUI, i.ToString() + " => " + txtInput.Text);
    
                    //txtOutput.AppendText(Environment.NewLine + i.ToString());
    
    
                    if (_cancelToken.IsCancellationRequested)
                    {
                        this.Invoke(_updateGUI, "Task cancellation requested at " + DateTime.Now.ToString());
                        break;
                    }
                }
                _updateGUI = null;
            }
    
    
            private void SetUI(dynamic output)
            {
                //txtOutput.AppendText(Environment.NewLine + count.ToString() + " => " + txtInput.Text);
                txtOutput.AppendText(Environment.NewLine + output.ToString());
            }
    
            private void btnCancelTask_Click(object sender, EventArgs e)
            {
                _cancelToken = new CancellationToken(true);
            }
    
            private void btnPause_Click(object sender, EventArgs e)
            {
                _pauseTokeSource.IsPaused = !_pauseTokeSource.IsPaused;
                btnPause.Text = _pauseTokeSource.IsPaused ? "Resume" : "Pause";
            }
    }
     public class PauseTokenSource
        {
            public delegate void TaskPauseEventHandler(object sender, PauseEventArgs e);
            public event TaskPauseEventHandler onPause;
    
            private TaskCompletionSource<bool> _paused;
            internal static readonly Task s_completedTask = Task.FromResult(true);
    
            public bool IsPaused
            {
                get { return _paused != null; }
                set
                {
    
                    if (value)
                    {
                        Interlocked.CompareExchange(ref _paused, new TaskCompletionSource<bool>(), null);
                    }
                    else
                    {
                        while (true)
                        {
                            var tcs = _paused;
                            if (tcs == null) return;
                            if (Interlocked.CompareExchange(ref _paused, null, tcs) == tcs)
                            {
                                tcs.SetResult(true);
                                onPause?.Invoke(this, new PauseEventArgs(false));
                                break;
                            }
                        }
                    }
                }
            }
    
            public PauseToken Token
            {
                get
                {
                    return new PauseToken(this);
                }
            }
    
            internal Task WaitWhilePausedAsync()
            {
                var cur = _paused;
    
                if (cur != null)
                {
                    onPause?.Invoke(this, new PauseEventArgs(true));
                    return cur.Task;
                }
                return s_completedTask;
            }
        }
    
        public struct PauseToken
        {
            private readonly PauseTokenSource m_source;
            internal PauseToken(PauseTokenSource source) { m_source = source; }
    
            public bool IsPaused { get { return m_source != null && m_source.IsPaused; } }
    
            public Task WaitWhilePausedAsync()
            {
                return IsPaused ?
                    m_source.WaitWhilePausedAsync() :
                    PauseTokenSource.s_completedTask;
            }
        }
    
        public class PauseEventArgs : EventArgs
        {
            public PauseEventArgs(bool paused)
            {
                Paused = paused;
            }
            public bool Paused { get; private set; }
        }
