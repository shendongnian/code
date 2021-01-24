          string someString = "Test ";
          string val = someString.EndsWith(" ") ? TrimAndLog(someString)  : someString ;
          public string TrimAndLog(string someThing)
          {
                someThing = someThing.Trim(); //Trim will Trim all leading and Trailing whitespaces, You should use method TrimEnd
                Log("whitespaces trimmed");
                return someThing;
          }
