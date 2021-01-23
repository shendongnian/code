                var path = string.Empty;
                var path2 = string.Empty;
                var strFirst = string.Empty;
                var str = string.Empty;
                var strarrFirst = new List<string>();
                var strarrSecond = new List<string>();
    
                using (var first = new StreamReader(path))
                {
                    strFirst = first.ReadToEnd();
                }
    
                using (var second = new StreamReader(path2))
                {
                    str = second.ReadToEnd();
                }
    
                
                strarrFirst.AddRange(strFirst.Split('\n'));
               
                strarrSecond.AddRange(str.Split('\n'));
                strarrSecond.Sort();
    
                foreach(var value in strarrFirst)
                {
                    var found = strarrSecond.BinarySearch(value) >= 0;
                    if (!found) Console.WriteLine(value);
                }
