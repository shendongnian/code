private int _lastCount;
public void MyProc()
{
    //Get Count and Add 1 (74 to 75 to 76 etc..
    int count = _lastCount + 1;
    lblCount.Text = count.ToString();
    //Update the ID 
    txtID.Text = count.ToString();
    
    _lastCount = count;
}
otherwise you're adding two strings together, and the add operation with strings concatenates them.
