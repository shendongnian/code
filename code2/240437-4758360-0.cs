            WebClient web = new WebClient();
            System.IO.Stream stream = web.OpenRead("http://www.yoursite.com/resource.txt");
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                String text = reader.ReadToEnd();
            }
