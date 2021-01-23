       int id;
       var tmp = new List<string>();
       //------------------------------//
       foreach( string arg in ArgsList)
       {
           if( ( arg != "&&" && arg != "||" && arg != ")" && arg != "(" ) )
           {
              try
              {
                  id = int.Parse(arg);
              }
              catch( Exception ex )
              {
                   return false;
              }
              tmp.Add(GetRuleById(id, ref errorString).Check(wwObject, ref errorString).ToString());
           }
           else
           {
                tmp.Add(arg);
           }
      }
      //foreach converts it to List<string> = {"True","&&","False"}
      string stringtoeval;
      stringtoeval = string.Join(string.Empty, tmp.ToArray()).ToLower();//"True&&False"
      return (bool)EvalCSCode.EvalCSCode.Eval(stringtoeval);//returns false
