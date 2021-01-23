    List<String> controlsToChange =new List<String>{"lable1Name","lable2Name"};
    foreach(Control control in form.Controls)
    {
        if(control.GetType().Equals(typeof(Lable))
        {
             if( controlsToChange.Contains(control.Name)
             {
                  control.Forecolor=Colour.Black;
             }
        }
    }
