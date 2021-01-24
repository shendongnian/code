        private void test()
        {
            using (var client = new WebClient())
            {
                var s = client.DownloadString(@"myURL.html");
                var htmldoc2 = (IHTMLDocument2)new HTMLDocument();
                htmldoc2.write(s);
                var plainText = htmldoc2.body.outerText;
                label1.Text = plainText;
            }
        }
        int i = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i += 1;
            if (i >= 199)
            {
                i = 1;
                timer1.Stop();
                timer1.Start();
            }
            test();
        }
