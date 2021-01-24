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
If this doesnt help post some more code and I should be able to solve whats causing the issue. 
