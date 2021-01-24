class MyClass
{
    public event EventHandler MyEvent;
}
class MyClass
{
    private EventHandler myDelegate;
    public event EventHandler MyEvent
    {
        add => myDelegate += value;
        remove => myDelegate -= value;
    }
}
But suppose we don't use events, and use delegates directly. You could create a dictionary where the keys are delegates instead of events, but that wouldn't work for your problem. This is because **delegates are immutable**. You can't store a delegate in a collection and then retrieve it and clear its invokation list.
The only solution here would be to reference every event directly, like in this code. I'm not sure whether this solution will work for you.
using System;
using System.Threading;
using System.Windows.Forms;
namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            var ticker = new Ticker();
            var form = new Form();
            form.Show();
            form.FormClosing += (s, e) => ticker.ClearSubscriptions();
            ticker.Ticked += new EventHandler((s, e) => form.Invoke(
                new Action(() => form.Text = DateTime.Now.ToString())));
            Application.Run();
        }
        class Ticker
        {
            public event EventHandler Ticked;
            public Ticker()
            {
                new Thread(new ThreadStart(() => {
                    while (true)
                    {
                        Ticked?.Invoke(this, EventArgs.Empty);
                        Thread.Sleep(1000);
                    }
                })).Start();
            }
            public void ClearSubscriptions()
            {
                Ticked = null;
            }
        }
    }
}
As you can see, `ClearSubscriptions` clears the `Ticked` event manually. If you have more events, you must also clear them manually and only in the `Ticker` class, because it's the only place that has access to the underlying delegate. You can only clear the events you've declared yourself.
Alternatively, you could store a separate list for each event.
static void Main()
{
    var ticker = new Ticker();
    var form = new Form();
    form.Show();
    var tickedSubscriptions = new List<EventHandler>();
    form.FormClosing += (s, e) =>
    {
        foreach (var subscription in tickedSubscriptions)
        {
            ticker.Ticked -= subscription;
        }
        tickedSubscriptions.Clear();
    };
    var handler = new EventHandler((s, e) => form.Invoke(
        new Action(() => form.Text = DateTime.Now.ToString())));
    tickedSubscriptions.Add(handler);
    ticker.Ticked += handler;
    Application.Run();
}
But in my opinion, this solution is less than ideal, because you have to keep track of many separate lists.
**UPDATE:**
I've thought of another solution which works for your case. I'm not sure whether it's elegant though.
Even though delegates are immutable, nothing prevents us from creating wrapper objects that can change the backing delegate and put these wrappers into the dictionary.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
namespace ConsoleApp3
{
    class Program
    {
        private static Dictionary<EventHandlerWrapper, List<EventHandler>> subscriptions =
        new Dictionary<EventHandlerWrapper, List<EventHandler>>();
        static void Main()
        {
            var ticker = new Ticker();
            var form = new Form();
            form.Show();
            form.FormClosing += (s, e) =>
            {
                foreach (var subscription in subscriptions)
                {
                    foreach (var handler in subscription.Value)
                    {
                        subscription.Key.Remove(handler);
                    }
                }
                subscriptions.Clear();
            };
            var updateTitle = new EventHandler((s, e) =>
                form.Invoke(new Action(() => form.Text = DateTime.Now.ToString())));
            ticker.Ticked += updateTitle;
            subscriptions.Add(ticker.TickedWrapper, new List<EventHandler> { updateTitle });
            Application.Run();
        }
        class Ticker
        {
            public event EventHandler Ticked;
            public EventHandlerWrapper TickedWrapper;
            public Ticker()
            {
                TickedWrapper = new EventHandlerWrapper(
                    () => Ticked,
                    handler => Ticked += handler,
                    handler => Ticked -= handler);
                new Thread(new ThreadStart(() => {
                    while (true)
                    {
                        Ticked?.Invoke(this, EventArgs.Empty);
                        Thread.Sleep(1000);
                    }
                })).Start();
            }
        }
        class EventHandlerWrapper
        {
            public Func<EventHandler> Get { get; }
            public Action<EventHandler> Add { get; }
            public Action<EventHandler> Remove { get; }
            public EventHandlerWrapper(
                Func<EventHandler> get,
                Action<EventHandler> add,
                Action<EventHandler> remove)
            {
                this.Get = get;
                this.Add = add;
                this.Remove = remove;
            }
        }
    }
}
