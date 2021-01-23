using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace Net
{
    public class HttpHandler : IHttpHandler 
    {
        public void ProcessRequest(Type cobraType)
        {
            int a, b;
            foreach (var item in cobraType.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
            {
                if (item.Name == "A")
                    a = (int)item.GetValue(null, null);//Since it is a static class pass null
                else if (item.Name == "B")
                    b = (int)item.GetValue(null, null);
            }
        }
    }
}
