    public class CustomButtom : Button
    {
    
         public int ReferenceID {  
           get {
                  if(ViewState["ReferenceID"]!=null)
                    return int.Parse(ViewState["ReferenceID"].ToString());
                  return -1;
               }
          set  {
                 ViewState["ReferenceID"]=value;
               } 
    
         } 
    }
