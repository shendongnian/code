        public void JustATest()
        {
            DateTime date = new DateTime(2011, 5, 31);
            string url = ((Scraper)this).DateToUrl(date);
            Console.WriteLine(url);
        }
