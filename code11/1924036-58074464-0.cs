    [Given("The API returns line items for '(.*)'")]
    public void GivenTheAPIReturnsItemsForTime(string mydate)
    {
         switch (mydate)
         {
              case:"the current date":
                  HandleApiDateTime(DateTime.Now.ToString("dd-MM-yyyy"))
                  // pass the current date to the Api handler
                  break;
              case:"yesterday":
                  HandleApiDateTime(DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy"))
                  // pass yesterdays date to the Api handler
                  break;
              default:
                  Console.Writeline("I didnt recognize this command");
                  // or other error handling
                  break;
         }
    }
    
    private void HandleApiDateTime(DateTime mydate)
    {
        // do your api magic with a date object
    }
