            int number = 0;
            using (var sr = new StreamReader(fileName))
            {
                string fileContent = sr.ReadToEnd();
                Regex regex = new Regex(@"(?<=.*MERCHANTNO:)(?<number>\d*)");
                var match = regex.Match(fileContent);
                if (match.Groups["number"].Success)
                {
                    number = Convert.ToInt32(match.Groups["number"].Value);
                }
            }
            MessageBox.Show("MerchantNo is:" + number);
