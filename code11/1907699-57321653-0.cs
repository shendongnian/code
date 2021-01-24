                string iso = "áÁèÃÔÁ";
                string[] isoBytes = iso.Select(x => ((byte)x).ToString()).ToArray();
                Console.WriteLine("Iso " + string.Join(",",isoBytes));
                string win = "แม่ริม";
                string[] winBytes = win.Select(x => ((byte)x).ToString()).ToArray();
                Console.WriteLine("Windows " + string.Join(",",winBytes));
                Console.ReadLine();
