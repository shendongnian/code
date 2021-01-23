    using System;
    class Program
    {
        public class Ev
        {
            public int? RaiseSomeEvent()
            {
                if (SomeEvent != null)
                {
                    return SomeEvent();
                }
                return null;
            }
            public event Func<int> SomeEvent;
        }
        static void Main(string[] args)
        {
            var ev = new Ev();
            ev.SomeEvent += ev_someEvent1;
            ev.SomeEvent += ev_someEvent2;
            int? value = ev.RaiseSomeEvent();
            Console.WriteLine(value.HasValue ? value.Value.ToString() : "(null)");
        }
        static int ev_someEvent1()
        {
            return 5;
        }
        static int ev_someEvent2()
        {
            return 6;
        }
    }
