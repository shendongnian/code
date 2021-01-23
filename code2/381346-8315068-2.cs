        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Xml.Linq;
      public namespace WhateverNamespaceYouWant
      {
       public class Item
       {
          public bool IM { get; set;}
          public int AL { get; set; }
       }
       public Class ItemsRepository : IRepository<Item> 
       {
        public IEnumerable<Item> GetAllItemsInXML()
        {
            var _items = new List<Item>();
            var doc = XDocument.Load(xmlToParse);
            // finds every node of Item
            doc.Descendants("Item").ToList() 
            .ForEach(item =>
            {
               var myItem = new Item(); // your domain type
               {
                  IM = item.Element("IM").Value.ConvertToValueType<bool>(),
                  AL = item.Element("AL").Value.ConvertToValueType<int>(),                 
               };
               _items.Add(myItem);
            });
            return _items;
         }
        }
      
       public static class Extensions
       {
         public static T ConvertToValueType<T>(this string str) where T : struct
         {
           try
           {
              return (T)Convert.ChangeType(str, typeof(T));
           }
           catch
           {
            return default(T);
           }
         }
       }
       }
    
