     [ModelMetadataType(typeof(TblUserMetaData))]
            public partial class Status
            {
            }
        
            public class TblUserMetaData
            {
               public int Value{get;set;}
               public bool ValueBool{get{ 
                //gett Value variable by converting boolean
                };
             set{
                 //set Value variable by converting int
               };
              }
            }
        }
