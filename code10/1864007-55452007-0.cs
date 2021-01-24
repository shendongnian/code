                DateTime today = DateTime.Parse("2019-01-22 15:36:14");
                string input =
                    "2019-01-22 15:36:14,1023: [Test][123] INFORMATION - Testing: Correct Test12 ping\n" +
                    "2019-01-22 15:36:14,1023: [Test][124323] INFORMATION - Testing: Wrong Test12 ping\n" +
                    "2019-01-22 15:36:14,1023: [Test][12554363] INFORMATION - Testing: Correct Test ping\n" +
                    "2019-01-22 15:36:14,1023: [Test][6761213] INFORMATION - Testing: Wrong Test12 ping\n" +
                    "2019-01-22 15:36:14,1023: [Test][46543123] INFORMATION - Testing: Invalid Test ping\n" +
                    "2019-01-22 15:36:14,1023: [Test][887] INFORMATION - Testing: Correct Test ping";
                StringReader reader = new StringReader(input);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] splitDate = line.Split(new string[] { ": [Test]" }, StringSplitOptions.None);
                    DateTime date = DateTime.ParseExact(splitDate[0].Replace(",","."), "yyyy-MM-dd HH:mm:ss.FFFF", System.Globalization.CultureInfo.InvariantCulture);
                    string[] splitTest = splitDate[1].Split(new char[] { ':' });
                    if ((date.Date == today.Date) && splitTest[1].Contains("Correct") && !splitTest[1].Contains("Test12"))
                    {
                        Console.WriteLine(line);
                    }
                }
                Console.ReadLine();
