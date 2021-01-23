    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication22
    {
        
        [XmlRoot( "items" )]
        public class ItemList
        {
            public static ItemList CreateInstance( string xml )
            {
                ItemList instance = null ;
                
                using ( TextReader tr = new StringReader( xml ) )
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ItemList)) ;
                    
                    instance = (ItemList) serializer.Deserialize( tr ) ;
                
                }
                
                return instance ;
            
            }
            
            public SimpleItem[] Simplify()
            {
                return Items.OrderBy( x => x.Name     )
                            .ThenBy(  x => x.Position )
                            .GroupBy( x => x.Name , x => x , (name,group) => SimpleItem.CreateInstance(name,group) )
                            .ToArray()
                            ;
            }
            
            [XmlElement("item")]
            public Item[] Items { get ; set ; }
            
        }
        
        public class Item
        {
        
            [XmlAttribute("item")]
            public string Name { get ; set ; }
        
            [XmlAttribute("position")]
            public int Position { get ; set ; }
        
            [XmlElement("itemvalue")]
            public int Value { get ; set ; }
        
        }
        
        public class SimpleItem
        {
            
            public static SimpleItem CreateInstance( string name , IEnumerable<Item> items )
            {
                List<int> values = new List<int>() ;
                int       i      = 0 ;
                foreach( Item item in items.OrderBy( x => x.Position ) )
                {
                    if ( item.Position != i++ ) throw new InvalidOperationException("bad data") ;
                    values.Add(item.Value) ;
                }
                SimpleItem instance = new SimpleItem(name , values.ToArray() ) ;
                
                return instance ;
            }
            
            private SimpleItem( string name , int[] values )
            {
                this.Name    = name   ;
                this.Columns = values ;
                return ;
            }
            
            public string Name    { get ; private set ; }
            public int[]  Columns { get ; private set ; }
        
        }
        
        class Program
        {
            
            static void Main( string[] args )
            {
                string xml = @"
    <items>
     <item item=""A"" position=""0"">
       <itemvalue>10</itemvalue>
     </item>
      <item item=""A"" position=""1"">
        <itemvalue>20</itemvalue>
     </item>
      <item item=""A"" position=""2"">
        <itemvalue>30</itemvalue>
     </item>
      <item item=""B"" position=""0"">
        <itemvalue>10</itemvalue>
      </item>
       <item item=""B"" position=""1"">
         <itemvalue>20</itemvalue>
      </item>
       <item item=""B"" position=""2"">
         <itemvalue>30</itemvalue>
     </item>
    </items>
    " ;
                
                ItemList     instance = ItemList.CreateInstance(xml) ;
                SimpleItem[] items    = instance.Simplify() ;
                
                return ;
            }
        
        }
    
    }
