        class Test
        {
            public void A()
            {
                MessageBox.Show("Function A");
            }
        }
        class Test2: Test
        {
            public void B()
            {
                A();
            }
        }
