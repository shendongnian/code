    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace CoreConsole
    {
        class Program
        {
            static async Task Main(string[] args)
            {
                try
                {
                    using (var longRunningThread = new LongRunningThread(() => Thread.Sleep(5000)))
                    {
                        await Task.Delay(2500);
                        longRunningThread.Abort();
                        await longRunningThread.Completion;
                        Console.WriteLine("Finished");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    
        public class LongRunningThread : IDisposable
        {
            readonly Thread _thread;
    
            IntPtr _threadHandle = IntPtr.Zero;
    
            readonly TaskCompletionSource<bool> _threadEndTcs;
    
            readonly Task _completionTask;
    
            public Task Completion { get { return _completionTask; } }
    
            readonly object _lock = new object();
    
            public LongRunningThread(Action action)
            {
                _threadEndTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
    
                _thread = new Thread(_ =>
                {
                    try
                    {
                        var hCurThread = NativeMethods.GetCurrentThread();
                        var hCurProcess = NativeMethods.GetCurrentProcess();
                        if (!NativeMethods.DuplicateHandle(
                            hCurProcess, hCurThread, hCurProcess, out _threadHandle,
                            0, false, NativeMethods.DUPLICATE_SAME_ACCESS))
                        {
                            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                        }
    
                        action();
    
                        _threadEndTcs.TrySetResult(true);
                    }
                    catch (Exception ex)
                    {
                        _threadEndTcs.TrySetException(ex);
                    }
                });
    
                async Task waitForThreadEndAsync()
                {
                    try
                    {
                        await _threadEndTcs.Task.ConfigureAwait(false);
                    }
                    finally
                    {
                        // we use TaskCreationOptions.RunContinuationsAsynchronously for _threadEndTcs
                        // to mitigate possible deadlocks here
                        _thread.Join();
                    }
                }
    
                _thread.IsBackground = true;
                _thread.Start();
    
                _completionTask = waitForThreadEndAsync();
            }
    
            public void Abort()
            {
                if (Thread.CurrentThread == _thread)
                    throw new InvalidOperationException();
    
                lock (_lock)
                {
                    if (!_threadEndTcs.Task.IsCompleted)
                    {
                        _threadEndTcs.TrySetException(new ThreadTerminatedException());
                        if (NativeMethods.TerminateThread(_threadHandle, uint.MaxValue))
                        {
                            NativeMethods.WaitForSingleObject(_threadHandle, NativeMethods.INFINITE);
                        }
                        else
                        {
                            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                        }
                    }
                }
            }
    
            public void Dispose()
            {
                if (Thread.CurrentThread == _thread)
                    throw new InvalidOperationException();
    
                lock (_lock)
                {
                    try
                    {
                        if (_thread.IsAlive)
                        {
                            Abort();
                            _thread.Join();
                        }
                    }
                    finally
                    {
                        GC.SuppressFinalize(this);
                        Cleanup();
                    }
                }
            }
    
            ~LongRunningThread()
            {
                Cleanup();
            }
    
            void Cleanup()
            {
                if (_threadHandle != IntPtr.Zero)
                {
                    NativeMethods.CloseHandle(_threadHandle);
                    _threadHandle = IntPtr.Zero;
                }
            }
        }
    
        public class ThreadTerminatedException : SystemException
        {
            public ThreadTerminatedException() : base(nameof(ThreadTerminatedException)) { }
        }
    
        internal static class NativeMethods
        {
            public const uint DUPLICATE_SAME_ACCESS = 2;
            public const uint INFINITE = uint.MaxValue;
    
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetCurrentThread();
    
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetCurrentProcess();
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool CloseHandle(IntPtr handle);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool DuplicateHandle(IntPtr hSourceProcessHandle,
               IntPtr hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle,
               uint dwDesiredAccess, bool bInheritHandle, uint dwOptions);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool TerminateThread(IntPtr hThread, uint dwExitCode);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
        }
    
    }
