    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
       public enum MyDataType
        {
            MyTypeString,
            MyTypeInt
        }
        public class MyStruct
        {
            public MyDataType type;
            public Object objDest;
    
            public MyStruct(MyDataType tType, Object oDest)
            {
                type = tType;
                objDest = oDest;
            }
        }
    
    public partial class _Default : System.Web.UI.Page
    {
    
    
        protected void Page_Load(object sender, EventArgs e)
        {
               //These are two variables to fill
                MyStruct strDest = new MyStruct(MyDataType.MyTypeString, "");
                MyStruct nDest = new MyStruct(MyDataType.MyTypeInt, 0);
    
                //Pass variables by reference -- this will work now because "MyStruct" is actually a reference type
                MyStruct[] data2Check = {
        strDest, //reference to actual strDest object
        nDest, //reference to actual nDest object
    };
    
                //And set them
                foreach (var item in data2Check) //foreach will work instead of "for", there are some good reasons to prefer this in C#
                {
                    if (item.type == MyDataType.MyTypeString)
                    {
                        item.objDest = "New value"; // no need for a cast
                    }
                    else if (item.type == MyDataType.MyTypeInt)
                    {
                        item.objDest = 2;
                    }
                }
    
                Response.Write(strDest.objDest.ToString() + "<br/>" + nDest.objDest.ToString());
        }
    }
