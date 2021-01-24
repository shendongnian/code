                   var lines = new [] { name, FirstBlock, MonIstem, WedIstem, ThridBlock, FourthBlock, "Design Time", SixthBlock, TueIstem, ThurIstem, EighthBlock, NinthBlock, "Design Time", FriIstem };
                var names = new [] { "name", "FirstBlock", "MonIstem", "WedIstem", "ThirdBlock", "FourthBlock", "Design Time", "SixthBlock", "TueIstem", "ThurIstem", "EightBlock", "NinthBlock", "Design Time", "FriIstem", };
                var linesAndnames = lines.Zip(names, (l, n) => new { Line = l, Name = n });
                foreach (var ln  in linesAndnames)
                {
                  var path = $@"C:\Users\gn193755\Documents\{ln.Name}.txt";
                  File.WriteAllText(path, ln.Line);
                }
            }
