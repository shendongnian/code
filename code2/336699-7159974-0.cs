      public class BlogEntry
             {
              public int commentCount{
                get
                {
                 if(this.comments==null){
                   return this._commentCount
                 }else{
                   return this.Comments.count;
                 
                 }
                }
                set{
                  this._commentCount=value;
                }
            
            
            }
            //other properties...
            
            }
