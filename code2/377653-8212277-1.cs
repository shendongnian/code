using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace Net
{
    public class HttpHandler     
    {
        public void ProcessRequest(Type cobraType)
        {
            foreach (var item in cobraType.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
            {
                var value = item.GetValue(null, null);//Since it is a static class pass null
            }
        }
    }
}
