using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNet.DataProtection.Repositories;
namespace MySpace
{
    public class MyXmlRepository : IXmlRepository
    {
        public MyXmlRepository()
        {
            // Whatever I wanted injected in.
        }
        public IReadOnlyCollection<XElement> GetAllElements()
        {
            return null;
        }
        public void StoreElement(XElement element, string friendlyName)
        {
            // Persist something
        }
    }
}
If you register this in the IOC it'll start using it for key persistence, you can then do whatever you like.
