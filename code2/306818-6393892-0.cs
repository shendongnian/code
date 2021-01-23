    List<string> list = new List<string>();
                    list.Add("test1");
                    list.Add("test2");
                    list.Add("test3");
                    list.Add("test4");
                    
                    File.WriteAllLines(Application.StartupPath + "\\Text.txt", list.ToArray());
                    Process.Start("notepad.exe", Application.StartupPath + "\\Text.txt");
