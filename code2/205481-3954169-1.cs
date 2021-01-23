    if (myButton == btnFoo)
    {
        var bFlags =  BindingFlags.Instance | BindingFlags.NonPublic;
        typeof(Button).GetMethod("OnClick", bFlags)
                      .Invoke(myButton, new[] { EventArgs.Empty });
    }
