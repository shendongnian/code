    bool StringListEnded = false;    
                var resultGroup = new Dictionary<List<string>,bool>();
                foreach(List<string> list in StringListGroup){
                        bool StringTFound = false;
                        bool StringBFound = false;
                        foreach (string item in list)
                        {               
                           if(item == "someStringT")
                           {
                               StringTFound = true;
                           }
                           if(item == "someStringB")
                           {
                              StringBFound = true;
                           }
                        }
            //here you can save values in the dictionary against each list from the group and the possibility of occurring specific string using both flags for stringB and stringT
        if(StringTFound || StringBFound){
           resultGroup.Add(list,true);
        }
                    }
