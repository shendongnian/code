        public class CMyDataClass
        {
            // ...snipped definition...
        
            public virtual void FillData()
            {
            }
    
            static public CMyDataClass Create(int type)
            {
                switch (type)
                {
                    case 1:
                       return new COne(type);
                    case 2:
                       return new CTwo(type);
                    default:
                       return null // or throw an exception, whatever is appropriate
                }
            }
        }
    
        public class COne : CMyDataClass
        {
             public override void FillData()
             {
                  strIndex = "Index-One";
                  strName = "One";             
             } 
        }
    
        public class CTwo : CMyDataClass
        {
             public override void FillData()
             {
                  strIndex = "Index-Two";
                  strName = "Two";             
             } 
        }
    
    //....
        List<CMyDataClass> lstMyDataList = new List<CMyDataClass> { CMyDataClass.Create(1), 
                                                                     CMyDataClass.Create(2) }
    //....
    
    //....
        public void Func()
        {
            for (int index = 0; index < lstMyDataList.Count; index++)
            {
                lstMyDataList[index].FillData();
            }
        }
    //....
