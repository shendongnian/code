    // inside the control which contains your UserControlB
    public MainPage()
    {
        // find it by its Name
        UserControlB theOneIWantToUse = this.UserControlB_1;
        // once you identify it, you can get the Text value from it
        String s = theOneIWantToUse.Text;
    }
