public class DragableObject : MonoBehaviour{
//reference to the scriptable object
public DragableObjectSet RuntimeSet;
void OnEnable(){
    RuntimeSet.Add(this);
}
void OnDisable(){
    RuntimeSet.Remove(this);
    //you can put code checking if the runtime set is empty here
    //or you can put it in the DragableObjectSet Remove method
}
}
Scriptable object example code
public DragableObjectSet : ScriptableObject
{
    public List<DragableObject> RuntimeSet = new List<DragableObject>();
        
    public void Add(DragableObject obj){
        RuntimeSet.Add(obj);
    }
    public void Remove(DragableObject obj){
        RuntimeSet.Remove(obj);
        if(RuntimeSet.Count() == 0)
           //some code here raising an event (if desired)
    }
}
This type of object is called a runtime set and is detailed in this talk around the 40 minute mark.
https://www.youtube.com/watch?v=raQ3iHhE_Kk
