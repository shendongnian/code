        private static BindingFlags CheckPropBinding(string bindFlagSpec)         
        {
            BindingFlags binderFlag = BindingFlags.NonPublic;
            string bindLower = bindFlagSpec.ToLower(); //--lowers string parameter.            
            Match matchBinder; //--our matcher :).            
            string regex = "regex dummy"; /*--this is a dummy which will be replaced when I've found the appropriate regex to use. */            
            matchBinder = Regex.Match(bindLower, regex);
            if (matchBinder.Success) //--if success, will go on...            
            {
                foreach (BindingFlags t in bindings)
                {
                    if (bindLower.Contains(t.ToString()))
                    {
                        binderFlag = t;
                        break;
                    }
                }
            }
            return binderFlag; //--returned :).       
        }
