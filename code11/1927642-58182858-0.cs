    public class ContainingClass
    {
        public static bool InitRun = false;
        public void Init() //Executed once on the first update call
        {
      
        }
        public void Update() //Executed on every frame
        {
            if(!InitRun)
            {
                Init(); //Call intialization code
                InitRun = true; //set flag that initialization has been run
            }
        }
    }
