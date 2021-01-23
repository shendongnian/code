    class Test
    {
        void DoTest()
        {
            MonitoredList<IInterface> mlist1 = new MonitoredList<Inherited>(); //Error
            MonitoredList<Inherited> mlist2 = new MonitoredList<Inherited>();
            DoSomething1(mlist2); //Error converting MonitoredList<Inherited> to MonitoredList<IInterface>
            MonitoredList<IInterface> list1 = new MonitoredList<Inherited>(); //Error
            MonitoredList<Inherited> list2 = new MonitoredList<Inherited>();
            DoSomething2(list2); //Error converting List<Inherited> to List<IInterface>
            DoSomething3<Inherited>(mlist2); //Works fine
            DoSomething3(mlist2); //<Inherited> is redundant
        }
        void DoSomething1(List<IInterface> list)
        { }
        void DoSomething2(MonitoredList<IInterface> list)
        { }
        //Generic method
        void DoSomething3<T>(MonitoredList<T> list) where T : IInterface
        { }
    }
    interface IInterface { }
    class Inherited : IInterface { }
    class MonitoredList<T> { }
