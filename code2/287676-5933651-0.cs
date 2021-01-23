                var e = l_lstValues.GetEnumerator();
                e.MoveNext();
                while(e.MoveNext())
                {
                    var p = a.IndexOf(e.Current);
                    a = a.Insert(p, "~");
                }
                var splitStrings = a.Split(new string[]{" ~"},StringSplitOptions.None);
