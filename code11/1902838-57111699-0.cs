    public class ViewModel{
        public Dictionary DictOne {get;set;}
        public Dictionary DictTwo {get;set;}
    }
    
    public ActionResult Index()
    {
        Dictionary<int, string> DictOne = MyObjOne.DictOne;
        Dictionary<int, string> DictTwo= MyObjTwo.DictTwo;
    
        ViewModel model = new ViewModel(){
        DictOne = DictOne,
        DictTwo = DictTwo
        };
        return View(model);
    }
