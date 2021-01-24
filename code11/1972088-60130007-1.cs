var varToCheckIfChanged; //This is the variable you want to know if it is still the same
var tempVar; //This variable stores the original value, and every time the varToCheckIfChanged changed, you update it.
//Gets called on Start of the scene
void Start
{
     tempVar = varToCheckIfChanged;
}
//Gets called every frame
void Update
{
    if(varToCheckIfChanged != tempVar)
    {
        Debug.Log("Variable changed!"); //Debug when the variable is updated
        var tempVar = varToCheckIfChanged;
    }
    
}
