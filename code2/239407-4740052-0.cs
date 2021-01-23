                if (_objbefor != null)
                {
                    string _str = pf.GetValue(_objbefor, null).ToString();
                    _ObjBeforTostring.Add(pf.Name.ToString() + "  ::  ( " + _str + " )");
                    _ObjBeforTostring.Add("==============================");
                }
                
            }
            _ObjBeforTostring.Add("");
            _ObjBeforTostring.Add("*************After Object**********");
            _ObjBeforTostring.Add("");
            foreach (PropertyInfo pf in _PropertyInfo)
            {
                
                if (_objAfter != null)
                {
                    string _str = pf.GetValue(_objAfter, null).ToString();
                    _ObjBeforTostring.Add(pf.Name.ToString() + "  ::  ( " + _str+" )");
                    _ObjBeforTostring.Add("==============================");
                }
            }
