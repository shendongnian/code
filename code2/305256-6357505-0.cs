    public IList<string> QuestionIDs
    {
       get
       {
          var obj = ViewState["QuestionIDs"];
          if(obj == null)
          {
             obj  = new List<string>();
             ViewState["QuestionIDs"] = obj;
          }
          return (IList<string>)obj;
       }
    }
