    using System;
    using System.Collections.Generic;
    using C5;
    namespace ConsoleApplication13
    {
        class Program
        {
            static void Main( string[] args )
            {
                IEnumerable<Widget>  sourceData  = ReadWidgets();
                WidgetSearcher lookup = new WidgetSearcher( sourceData );
                // find all the Widgets where column 2 is >= 5 ;
                Widget[] results1 = lookup.Search( 2 , 5 ).ToArray();
                // find all the Widgets where column 0 is >= 3 ;
                Widget[] results2 = lookup.Search( 0 , 3 ).ToArray();
                return ;
            }
            private static IEnumerable<Widget> ReadWidgets()
            {
                //TODO: we need source data from somewhere. It gets provided here.
                throw new NotImplementedException();
            }
        }
        public class Widget
        {
            public const int ValueCount = 8;
            public string Name { get; private set; }
            public byte[] Values
            {
                get
                {
                    return (byte[])_values.Clone();
                }
            }
            private byte[] _values;
            public Widget( string name , byte[] values )
            {
                if ( name==null )
                    throw new ArgumentNullException( "name" );
                if ( name.Trim()=="" )
                    throw new ArgumentOutOfRangeException( "name" );
                if ( values==null )
                    throw new ArgumentNullException( "values" );
                if ( values.Length!=ValueCount )
                    throw new ArgumentOutOfRangeException( "values" );
                this.Name=name;
                this._values=values;
                return;
            }
            /// <summary>
            /// private constructor for search instances
            /// </summary>
            /// <param name="column"></param>
            /// <param name="value"></param>
            private Widget( int column , byte value )
            {
                this.Name=null;
                this._values=new byte[Widget.ValueCount];
                this._values.Initialize();
                this._values[column]=value;
                return;
            }
            public class Comparer : IComparer<Widget> , IEqualityComparer<Widget>
            {
                private int ColumnToCompare;
                public Comparer( int colNum )
                {
                    if ( colNum<0||colNum>=Widget.ValueCount )
                        throw new ArgumentOutOfRangeException( "colNum" );
                    this.ColumnToCompare=colNum;
                }
                #region IComparer<Widget> Members
                public int Compare( Widget x , Widget y )
                {
                    return (int)x._values[this.ColumnToCompare]-(int)y._values[this.ColumnToCompare];
                }
                #endregion
                #region IEqualityComparer<Widget> Members
                public bool Equals( Widget x , Widget y )
                {
                    return ( x._values[this.ColumnToCompare]==x._values[this.ColumnToCompare] );
                }
                public int GetHashCode( Widget obj )
                {
                    return obj._values[this.ColumnToCompare].GetHashCode();
                }
                #endregion
            }
            internal static Widget CreateSearchInstance( int column , byte value )
            {
                return new Widget( column , value );
            }
        }
        public class WidgetSearcher
        {
            private C5.TreeBag<Widget>[] lookups;
            public WidgetSearcher( IEnumerable<Widget> sourceData )
            {
                this.lookups=InstantiateLookups();
                PopulateLookups( sourceData );
            }
            private TreeBag<Widget>[] InstantiateLookups()
            {
                C5.TreeBag<Widget>[] instance =new C5.TreeBag<Widget>[Widget.ValueCount];
                for ( int i = 0 ; i<instance.Length ; ++i )
                {
                    Widget.Comparer widgetComparer = new Widget.Comparer( i );
                    instance[i]=new TreeBag<Widget>( widgetComparer , widgetComparer );
                }
                return instance;
            }
            private void PopulateLookups( IEnumerable<Widget> sourceData )
            {
                foreach ( Widget datum in sourceData )
                {
                    for ( int i = 0 ; i<Widget.ValueCount ; ++i )
                    {
                        lookups[i].Add( datum );
                    }
                }
                return;
            }
            public IDirectedCollectionValue<Widget> Search( int column , byte value )
            {
                Widget limit = Widget.CreateSearchInstance( column , value );
                return lookups[column].RangeFrom( limit );
            }
        }
    }
