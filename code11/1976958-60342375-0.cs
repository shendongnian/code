        static async void f()
        {
            await h();
        }
        static async Task g()
        {
            await h();
        }
        static async Task h()
        {
            throw new NotImplementedException();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            g();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
