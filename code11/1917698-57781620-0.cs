    string temp = "Oliver/Christina=2373400019485 Ortosan/David=2373400019486";
                var PersonstrList = temp.Split(' ');
                List<Test> PersonList = new List<Test>();
                foreach (var p in PersonstrList)
                {
                    Test t = new Test();
                    t.LastName = p.Substring(0,p.IndexOf("/"));
                    t.FirstName = p.Substring(p.IndexOf("/"), p.IndexOf("/") - p.IndexOf("="));
                    t.Code = p.Substring(p.IndexOf("="));
                    PersonList.Add(t);
                }
