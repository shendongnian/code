    public IEnumerable<KeyValuePair<string,string>> FlattenRoles(IEnumerable<MyRole> roles)
    {
        int iRole=0;
        foreach(var role in roles)
        {           
            var rolePart=$"Policy:roles:{i}";
            var namePair=new KeyValuePair($"{rolePart}:name",role.Name);
            yield return namePair;
            int iSubject=0;
            foreach(var subjectPair in FlattenSubjects(role.Subject))
            {
                yield return subjectPair
            }
            //Same for identity roles etc
            iRole++;
        }
    }
    public IEnumerable<KeyValuePair<string,string>> FlattenSubjects(IEnumerable<MySubject> subjects,string rolePart)
    {
        var pairs=subjects.Select((subject,idx)=>
                  new KeyValuePair($"{rolePart}:subjects:{idx}",subject.Value);
        return pairs;
    }
