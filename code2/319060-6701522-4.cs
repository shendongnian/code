    ///<summary>
    ///Computes numeric ranges using a BaseConverter.
    ///</summary>
    public class NumericRangeFactory
    {
       private long _min, _length;
       private BaseConverter _converter;
       
       //creates a new NumericRangeFactory
       //converter - the BaseConverter that defines the number system 
       //being used
       //min - the smallest value in an acceptable range
       //length - the number of values in a single range
       public NumericRangeFactory(BaseConverter converter, long min, 
          long length)
       {
          _converter = converter; _min = min; _length = length;
       }
    
       public NumericRangeFactory(BaseConverter converter, string min, 
          long length) : this(converter.StringToLong(min), length) {}
    
       //returns an array of long containing the min and max of the 
       //range that contains value
       public long[] GetLongRange(long value)
       {
          long min = _length * (value / _length);'
          if (min < _min) min = _min;
          return new long[] { min, min + length - 1 };    
       }
    
       public long[] GetLongRange(string value)
       {
          return GetLongRange(_converter.StringToLong(value));
       }
    
       //returns an array of string containing the min and max of 
       //the range that contains value
       public string[] GetStringRange(long value)
       {
          long[] range = GetLongRange(value);
          return new string[] {_converter.LongToString(range[0]),
             _converter.LongToString(range[1])};
       }
    
       public string[] GetStringRange(string value)
       {
          return GetStringRange(_converter.StringToLong(value));
       }
    }
