        private void button1_Click(object sender, EventArgs e) {
            using (new Loader(this, new LoadingForm())) {
                System.Threading.Thread.Sleep(3000);
            }
        }
