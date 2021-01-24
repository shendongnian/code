    namespace Client
    {
        public class ClientAction
        {
            public ClientAction()
            {
                Engine.Engine1.OpenForm += Engine1_OpenForm;
            }
    
            private void Engine1_OpenForm(object sender, Engine.OpenFormEventArgs e)
            {
                OpenForm(e.Obj1, e.Obj2);
            }
    
            public void OpenForm(object obj1, object obj2)
            {
                new Form1()
                {
                    Text = "OpenForm(object obj1, object obj2)"
                }.Show();
            }
        }
    }
