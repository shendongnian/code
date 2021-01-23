            string[] tests = {
                    @"snip...  flashvars.image_url = 'http://domain.com/test.jpg' ..snip",
                    @"snip...  flashvars.image_url = 'http://domain.com/test.jpg' flashvars2.image_url = 'http://someother.domain.com/test.jpg'",
            };
            string[] patterns = {
                    @"(?<==\s')[^']*(?=')",
                    @"=\s*'(.*)'",
                    @"=\s*'([^']*)'",
                                 };
            foreach (string pattern in patterns)
            {
                Console.WriteLine();
                foreach (string test in tests)
                    foreach (Match m in Regex.Matches(test, pattern))
                    {
                        if (m.Groups.Count > 1)
                            Console.WriteLine("{0}", m.Groups[1].Value);
                        else
                            Console.WriteLine("{0}", m.Value);
                    }
            }
