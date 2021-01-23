    protected void MyBtnHandler(Object sender, EventArgs e)
    {
         LinkButton btn = (LinkButton)sender;
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
