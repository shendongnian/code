    private void Form2_Load(object sender, EventArgs e)
            {
                test(1);
            }
            public void test(int a1)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int i = a1; i < 1000; i++)
                    {
                        label1.Invoke(new MethodInvoker(delegate { label1.Text = i.ToString(); }));
                    }
                });
            }
