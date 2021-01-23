    public class UpperCaseUTF8Encoding : UTF8Encoding
    {
      // Code from a blog http://www.distribucon.com/blog/CategoryView,category,XML.aspx
      //
      // Dan Miser - Thoughts from Dan Miser
      // Tuesday, January 29, 2008 
      // He used the Reflector to understand the heirarchy of the encoding class
      //
      //      Back to Reflector, and I notice that the Encoding.WebName is the property used to
      //      write out the encoding string. I now create a descendant class of UTF8Encoding.
      //      The class is listed below. Now I just call XmlTextWriter, passing in
      //      UpperCaseUTF8Encoding.UpperCaseUTF8 for the Encoding type, and everything works
      //      perfectly. - Dan Miser
      public override string WebName
      {
        get { return base.WebName.ToUpper(); }
      }
      public static UpperCaseUTF8Encoding UpperCaseUTF8
      {
        get
        {
          if (upperCaseUtf8Encoding == null) {
            upperCaseUtf8Encoding = new UpperCaseUTF8Encoding();
          }
          return upperCaseUtf8Encoding;
        }
      }  
      private static UpperCaseUTF8Encoding upperCaseUtf8Encoding = null;
    }
