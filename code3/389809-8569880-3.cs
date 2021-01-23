    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Spire.Xls;
    using System.Drawing;
    
    namespace _4SeriersChart
    {
        public class Country:IComparable<Country>
        {
            public string Name { get; set; }
            public string Capital { get; set; }
            public string Continent { get; set; }
            public float Area { get; set; }
            public float Population { get; set; }
            public Image Flag { get; set; }
    
            public static Comparison<Country> compare =
                    delegate(Country p1, Country p2)
                    {
                        if( p1.Continent.CompareTo(p2.Continent)==0)
                        {
                            return p1.Name.CompareTo(p2.Name);
                        }
                        else
                             return p1.Continent.CompareTo(p2.Continent);
                    };
    
    
            #region IComparable<Country> Members
    
            public int CompareTo(Country other)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    }
