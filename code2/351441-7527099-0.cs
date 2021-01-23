    DateTime enteredDateTime;
    if (!DateTime.TryParse(txt_SendAt.Text, out enteredDateTime))
    {
       Debug.WriteLine("User entered date time in wrong format");
    }else
    {
       if(enteredDateTime <= DateTime.Now)
       {
          // less or equal
       }
    }
