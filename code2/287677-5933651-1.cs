                string a = "List_1 fooo asdf List_2 bar fdsa XList_3 fooo bar";
                List<String> l_lstValues = new List<string> { "List_1", 
                                                          "XList_3", "List_2" };
                var e = l_lstValues.GetEnumerator();
                e.MoveNext();
                while(e.MoveNext())
                {
                    var p = a.IndexOf(e.Current);
                    a = a.Insert(p, "~");
                }
                var splitStrings = a.Split(new string[]{" ~"},StringSplitOptions.None);
