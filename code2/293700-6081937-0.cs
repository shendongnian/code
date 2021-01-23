        public class ButtonActions
        {
            public void DoSomething() {...}
            public void DoSomething2() {...}
            public void DoSomething3() {...}
            public void DoAll()
            {
                DoSomething();
                DoSomething2();
                DoSomething3();
            }
        }
        // here instead of clicking all buttons call method that does it all
        protected void button_Click(object sender, EventArgs e)
        {
            var buttonActions = new ButtonActions();
            buttonActions.DoAll();
        }
