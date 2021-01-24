public class BigGenerator : IGeneratorType{
    private List<GameObject> generatedObjects;
    public BigGenerator(/*List<GameObject> previousObjects*/){
        //generatedObjects = previousObjects;
    }
    public void Generate(){
        //...
        if(somespecificothercond){
            generatedObjects.Add(Object.Instantiate(...));
        }
        if(somecondition){
            Object.Destroy(generatedObjects[0])
        }
    }
    public IGeneratorType Transition(){
        return new SmallGenerator(/*generatedObjects*/);
    }
}
This works because Instantiate and Destroy are static methods from "Object", of which "GameObject" inherits.
However this doesn't solve the problem in case one really HAS TO inherit from monobehaviour
