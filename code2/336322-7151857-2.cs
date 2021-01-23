    public void Call(Stream str)
        {
            //Single Permission
            Generate[permission](str);
            //Say this user has multiple permissions, you can iterate over them
            IEnumerable<string> userPerms = GetUserPerms();
            foreach (var perm in userPerms)
            {
                Generate[perm](str);
            }
        }
        public static Dictionary<string, Func<Stream, object>> Generate
        {
            get
            {
                var ret = new Dictionary<string, Func<Stream, object>>();
                ret.Add("PermissionA",  (s) => 
                                            {
                                                Class1 cl1 = new Class1(s);
                                                Class4 cl4 = new Class4(s);
                                                Class6 cl6 = new Class6(s);
                                                cl1.Method2();
                                                cl1.Method7();
                                                cl4.Method1();
                                                cl4.Method2();
                                                cl6.Method1();
                                                cl6.Method2();
                                                cl1.DoXml();
                                                cl4.DoXml();
                                                cl6.DoXml();
                                                return "";
                                            });
                ret.Add("PermissionB", (s) => 
                                            {
                                                Class2 cl2 = new Class2(s);
                                                Class3 cl3 = new Class3(s);
                                                Class5 cl5 = new Class5(s);
                                                cl2.Method2();
                                                cl2.Method7();
                                                cl3.Method1();
                                                cl3.Method2();
                                                cl5.Method1();
                                                cl5.Method2();
                                                cl2.DoXml();
                                                cl3.DoXml();
                                                cl5.DoXml();
                                                return "";
                                            });
                return ret;
            }
        }
