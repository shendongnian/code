var varToCheckIfChanged; //This is the variable you want to know if it is still the same
var tempVar; //This variable stores the original value, and every time the varToCheckIfChanged changed, you update it.
void Start
{
     tempVar = varToCheckIfChanged;
}
void Update
{
    if(varToCheckIfChanged != tempVar)
    {
        Debug.Log("Variable changed!"); //Debug when the variable is updated
        var tempVar = varToCheckIfChanged;
    }
    
}
