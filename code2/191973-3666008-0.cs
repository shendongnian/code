        #region object data ...
        var model = new HcmlDocumentProductionModel();
        model.CaseID = "A001";
        model.CaseConductor = new CaseConductor();
        model.CaseConductor.AField = "AField";
        model.CaseConductor.Person = new Person();
        model.CaseConductor.Person.Surname = "{Smith}";
        model.CaseConductor.Person.DOB = DateTime.Now;
        model.CaseConductor.CaseNoteList = new List<Note>();
        model.CaseConductor.CaseNoteList.Add(new Note { NoteText = "A-1", NoteDt = DateTime.Now, NoteTypeEnum = NoteTypeEnum.CaseNote });
        model.CaseConductor.CaseNoteList.Add(new Note { NoteText = "B-2", NoteDt = DateTime.Now, NoteTypeEnum = NoteTypeEnum.ReferralNote });
        model.CaseConductor.CaseNoteList.Add(new Note { NoteText = "C-3", NoteDt = DateTime.Now, NoteTypeEnum = NoteTypeEnum.StatusNote });
        model.CaseConductor.CaseNoteList.Add(new Note { NoteText = "d-3", NoteDt = DateTime.Now, NoteTypeEnum = NoteTypeEnum.CaseNote });
        model.CaseConductor.CaseNoteList.Add(new Note { NoteText = "e-3", NoteDt = DateTime.Now, NoteTypeEnum = NoteTypeEnum.StatusNote });
        model.CaseConductor.CaseNoteList.Add(new Note { NoteText = "f-3", NoteDt = DateTime.Now, NoteTypeEnum = NoteTypeEnum.CaseNote });
        #endregion
        string head = "";
        string tail = "";
        // tail
        tail = "".Tail();
        tail = "Surname".Tail();
        tail = "Person.Surname".Tail();
        tail = "CaseConductor.Person.Surname".Tail();
        // head 
        head = "".Head();
        head = "Surname".Head();
        head = "Person.Surname".Head();
        head = "CaseConductor.Person.Surname".Head();
        // ObjectDictionary
        //var person = new Person { Surname = "Smith" };
        //var d = person.ObjectDictionary();
        //object ovalue = d["Surname"]; 
        // get value special
        object o2 = model.CaseConductor.Person.ValueByKey("Surname");
        object o3 = model.CaseConductor.Person.ValueByKey("DOB");
        object o4 = model.CaseConductor.ValueByKey("Person.Surname");
        object o5 = model.ValueByKey("CaseConductor.Person.Surname");
        // get the list of ...
        object o6 = model.ValueByKey("CaseConductor.CaseNoteList");
        // get item - index thing does not work - get anull here
        string noteText = model.CaseConductor.CaseNoteList[1].NoteText;
        object o7 = model.ValueByKey("CaseConductor.CaseNoteList[1].NoteText");
    namespace Zed
    {
        public static class Zed
        {
            public static object ValueByKey(this object o, string key)
            {
                if (!String.IsNullOrEmpty(key))
                {
                    if (!key.Contains("."))
                    {
                        return (o.ObjectDictionary())[key];
                    }
                    else
                    {
                        // key contains a dot ; therefore get object by the name of the head 
                        // and pass on that object and get propety by the tail
                        var d = o.ObjectDictionary();
                        var head = key.Head();
                        if (head.Contains("["))
                        {
                            string headMinusIndexer = head.Substring(0, head.IndexOf("["));
                            string indexString = head.Between("[", "]");
                            int index = Convert.ToInt32(indexString);
                            object oArray = d[headMinusIndexer];
                            //List<object> oList= d[headMinusIndexer]; 
                            // now get the object with the index, ... and continue
                            //object el = ((object[])oArray)[index];
                            return null;
                        }
                        else
                        {
                            var onext = d[head];
                            return onext.ValueByKey(key.Tail());
                        }
    
                    }
                }
                return null;
            }
    
            public static Dictionary<string,object> ObjectDictionary(this object o)
            {
                return o.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(o, null));
            }
            public static string Head(this  string key)
            {
                var head = String.Empty;
                var splittBy = '.';
                if (!String.IsNullOrEmpty(key))
                {
                    var keyArray = key.Split(splittBy);
                    head = keyArray[0];
                }
                //-Return
                return head;
            }
            public static string Tail(this string key)
            {
                var tail = "";
                var splittBy = '.';
                if (!String.IsNullOrEmpty(key))
                {
                    var keyArray = key.Split(splittBy);
                    for (int i = 1; i < keyArray.Length; i++)
                    {
                        tail += (i > 1) ? "." + keyArray[i] : keyArray[i];
                    }
                }
                //-Return
                return tail;
            }
            public static string Between(this string head, string start, string end)
            {
                string between = String.Empty ;
                between = head.Substring(head.IndexOf(start) + 1, head.IndexOf(end) - head.IndexOf(start) - 1);
                return between;
            }
    
            public static object ZGetValue( this object o, string propertyName)
            {
                Type type = o.GetType();
                PropertyInfo propertyInfo = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name == propertyName).FirstOrDefault();
                if (propertyInfo != null)
                {
                    return propertyInfo.GetValue(o, BindingFlags.Instance, null, null, null);
                }
                else
                {
                    return null;
                }
            }
        }
    
    }
