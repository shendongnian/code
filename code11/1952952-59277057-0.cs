    ClassB _b;
    ClassC _c;
 
    void Start()
    {
        _b = new ClassB();
        _c = new ClassC();
   
        _c.Button.onClick.AddListener(() => {
            if(!_b.IsRunning)
            {
                _b.SomeTask();
            }
        });
    }
    public class ClassB{
 
    public bool IsRunning {get; private set;}
 
    public async Task SomeTask()
    {
        IsRunning = true;
   
        //do stuff
   
        IsRunning = false;
    }}
    public class ClassC{
    public UIButton Button;}
  
 
 
 
