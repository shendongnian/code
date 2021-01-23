    namespace SmartThread
    {
        using System.Threading;
    public interface Iwinforms
    {
        object[] Data { get; }
        void UpdateElement(SynchronizationContext context, SendOrPostCallback thraedStart, object @Object);
    }
    public interface Iwpf
    {
        object[] Data { get; }
        void UpdateElement(Action threadStart);
    }
    public class SmartThread : Iwpf, Iwinforms
    {
        object[] Iwinforms.Data { get { return d; } }
        object[] Iwpf.Data { get { return d; } }
        private static object[] d;
        public SmartThread()
        {
        }
        public SmartThread(params object[] sData)
        {
            d = sData;
        }
        void Iwinforms.UpdateElement(SynchronizationContext context, SendOrPostCallback threadStart, object @Object)
        {
            ThreadPool.QueueUserWorkItem((e) => { Thread.CurrentThread.Priority = ThreadPriority.Lowest; context.Post(threadStart, Object); });
        }
        void Iwpf.UpdateElement(Action threadStart)
        {
            ThreadPool.QueueUserWorkItem(async(e) => { Thread.CurrentThread.Priority = ThreadPriority.Lowest; await Application.Current.Dispatcher.BeginInvoke(threadStart); });
        }
    }
    }
