      string input = @" <name>AAA</name>
                                    <id>1234</id>
                                    <gender>M</gender>";
              string pattern = @"<name>(?<name>.+)</name>
                                    <id>(?<id>.+)</id>
                                    <gender>(?<gender>.+)</gender>";
              Match m = Regex.Match(input, pattern);
              Console.WriteLine(m.Groups["name"]);
              Console.WriteLine(m.Groups["id"]);
              Console.WriteLine(m.Groups["gender"]);
