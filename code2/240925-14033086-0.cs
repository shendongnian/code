    class Program
    {
        static void Main(string[] args)
        {
            Link link = LinkFactory.GetLink("id", () =>
            // This would be your onClick method.
            {
                    // SetResponsePage(...);
                    Console.WriteLine("Clicked");
                    Console.ReadLine();
            });
            link.FireOnClick();
        }
        public static class LinkFactory
        {
            private class DerivedLink : Link
            {
                internal DerivedLink(String id, Action action)
                {
                    this.ID = id;
                    this.OnClick = action;
                }
            }
            public static Link GetLink(String id, Action onClick)
            {
                    return new DerivedLink(id, onClick);
            }
        }
        public abstract class Link
        {
            public void FireOnClick()
            {
                OnClick();
            }
            public String ID
            {
                get;
                set;
            }
            public Action OnClick
            {
                get;
                set;
            }
        }
    }
