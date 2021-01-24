    public class B
    {
        // subscribe the closure and delete it once it is invoked, can unsubscribe at anytime.
        void subscribe(A a)
        {
            string name = "one shot subscriber";
            Action showName = null;
            showName = () =>
            {
                print(name);
                a.process -= showName;
            };
            a.process += showName;
        }
        private void print(string s)
        {
            // ....
        }
    }
