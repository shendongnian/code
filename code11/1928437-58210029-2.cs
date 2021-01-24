    public class CallingDoSomething
    {
        private List<IDoSomething> m_somethingDoers = new List<IDoSomething>();
        public void OtherCodeThatPopulatedSomethingDoers()
        {
            // ...
        }
        public void CallAllSomethings()
        {
            foreach (var s in m_somethingDoers)
                s.Dosomething();
        }
    }
