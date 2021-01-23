    public class TestClass
    {
        public class MyButton : Button
        {
            public EventHandler ClickSubscriber
            {
                get { return null; }
                set { Click += value; }
            }
        }
    
        public static void RunTest()
        {
            new Form
                {
                    Text = "Caption",
    
                    Controls =
                        {
                            new MyButton 
                                { 
                                    ClickSubscriber = (s, e) => 
                                         MessageBox.Show("Button 1 Clicked"), 
                                },
                        },
                };
        }        
    }
