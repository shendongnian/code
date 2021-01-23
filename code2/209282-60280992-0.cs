           private void Button_Click(object sender, RoutedEventArgs e)
            {
                string filepath = @"C:\Users\Testing\Documents\sample1.txt";
                string htmlString = File.ReadAllText(filepath);
                string htmlTagPattern = "<.*?>";
                Regex oRegex = new Regex(".*?<body.*?>(.*?)</body>.*?", RegexOptions.Multiline);
                htmlString = oRegex.Replace(htmlString, string.Empty);
                htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
                htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
                htmlString = htmlString.Replace("&nbsp;", string.Empty);
            }
