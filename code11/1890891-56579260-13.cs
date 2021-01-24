    namespace Client
    {
        public class ClientAction
        {
            public ClientAction() { }
    
            public void OpenForm(object obj1, object obj2)
            {
                new Form1()
                {
                    Text = "OpenForm(object obj1, object obj2)"
                }.Show();
            }
        }
    }
