    void MyBtnHandler(Object sender, EventArgs e)
    {
       Button btn = (Button)sender;
       switch (btn.CommandName)
       {
          case "ThisBtnClick":
             DoWhatever(btn.CommandArgument.ToString());
             break;
          case "ThatBtnClick":
             DoSomethingElse(btn.CommandArgument.ToString());
             break;
       }
    }
