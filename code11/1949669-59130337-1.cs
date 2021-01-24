YourModel VarName { get; set; }
string YourStr { get; set; }
protected override void OnNavigatedTo(NavigationEventArgs e){
    base.OnNavigatedTo(e);
    if (e.Parameter is string){  //common variable
        YourStr = e.Parameter;  //YourStr = e.Parameter.StrProp; //may need .ToString() for some
    }
    else //using a Model
    {
      YourModel = e.Parameter; // YourModel.YourProp = e.Parameter.YourProp;
    }
    //Use newly bound YourModel/YourStr here/elsewhere or call another function
    //function();
}
**UPDATE 2:**
Would you be able to add more code with that error I believe it has something to do with your Navigation and declaring the Frame or declaring which Page you are Navigating too, if you post some code I may be able to see it easier. Im sure youre really close but I believe you forgot to declare your frame in ```OpenAppButton.Click += async delegate { Frame.Navigate(typeof(AppDisplay), AppDataTemp); };``` and Im not sure how your layout is but you should be able to pull whatever you declared your Frame from in App.xaml.cs or create an instance on each page using something like 
