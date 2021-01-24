    var textBoxData =
                    "SESSIONNAME       USERNAME                 ID  STATE   TYPE        DEVICE\r\nconsole           mlynch                    9  Active";
                var stringCollection = textBoxData.Split(new[] { Environment.NewLine, "  " }, StringSplitOptions.RemoveEmptyEntries);
                var finalCollection = new List<int>();
                foreach (var s1 in stringCollection)
                {
                    int n;
                    if (int.TryParse(s1, out n))
                    {
                        finalCollection.Add(n);
                    }
                }
