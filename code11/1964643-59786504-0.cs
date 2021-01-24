        public class Sol1
        {
            internal IList<MenuItem> MenuItems { get; private set; }
            internal async Task GetItems()
            {
                // some async code
                // ...
                MenuItems = someResult;
            }
        }
        public class Sol2
        {
            private async Task SecondLevel()
            {
                //some code
                Sol1 sol1 = new Sol1();
                await sol1.GetItems();
                var test = sol1.MenuItems;
            }
        }
