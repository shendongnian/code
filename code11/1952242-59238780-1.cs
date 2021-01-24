    #region using statements
    
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    #endregion
    
    namespace TransparencyMaker.Objects
    {
    
        #region class PixelInformation
        /// <summary>
        /// This class is used to contain information about a pixel, and 
        /// </summary>
        public class PixelInformation
        {
    
            #region Private Variables
            private int index;
            private Color color;
            private int x;
            private int y;
            #endregion
    
            #region Constructor
            /// <summary>
            /// Create a new instance of a PixelInformationObject
            /// </summary>
            public PixelInformation()
            {
                // Perform initializations for this object
                Init();
            }
            #endregion
    
            #region Methods
    
                #region Init()
                /// <summary>
                /// This method performs initializations for this object.
                /// </summary>
                public void Init()
                {
                }
                #endregion
    
                #region ToString()
                /// <summary>
                /// method returns the String
                /// </summary>
                public override string ToString()
                {
                    // Create a new instance of a 'StringBuilder' object.
                    StringBuilder sb = new StringBuilder();
    
                    // Append the string
                    sb.Append("R:");
                    sb.Append(Red);
                    sb.Append("G:");
                    sb.Append(Green);
                    sb.Append("B:");
                    sb.Append(Blue);
                    sb.Append("T:");
                    sb.Append(Total);
                    
                    // set the return value
                    string toString = sb.ToString();
    
                    // return value
                    return toString;
                }
                #endregion
                
            #endregion
    
            #region Properties
    
                #region Alpha
                /// <summary>
                /// This property gets or sets the value for 'Alpha'.
                /// </summary>
                public int Alpha
                {
                    get 
                    { 
                        // initial value
                        int alpha = Color.A;
    
                        // return value
                        return alpha; 
                    }
                }
                #endregion
    
                #region Blue
                /// <summary>
                /// This property gets or sets the value for 'Blue'.
                /// </summary>
                public int Blue
                {
                    get 
                    { 
                        // initial value
                        int blue = Color.B;
    
                        // return value
                        return blue; 
                    }
                }
                #endregion
                
                #region BlueGreen
                /// <summary>
                /// This read only property returns the value for 'BlueGreen'.
                /// </summary>
                public int BlueGreen
                {
                    get
                    {
                        // initial value
                        int blueGreen = Blue + Green;
                        
                        // return value
                        return blueGreen;
                    }
                }
                #endregion
    
                #region BlueRed
                /// <summary>
                /// This read only property returns the value for 'BlueRed'.
                /// </summary>
                public int BlueRed
                {
                    get
                    {
                        // initial value
                        int blueRed = Blue + Red;
                        
                        // return value
                        return blueRed;
                    }
                }
                #endregion
                
                #region Color
                /// <summary>
                /// This property gets or sets the value for 'Color'.
                /// </summary>
                public Color Color
                {
                    get { return color; }
                    set { color = value; }
                }
                #endregion
                
                #region Green
                /// <summary>
                /// This property gets or sets the value for 'Green'.
                /// </summary>
                public int Green
                {
                    get 
                    { 
                        // initial value
                        int green = Color.G;
    
                        // return value
                        return green;
                    }
                }
                #endregion
    
                #region GreenRed
                /// <summary>
                /// This read only property returns the value for 'GreenRed'.
                /// </summary>
                public int GreenRed
                {
                    get
                    {
                        // initial value
                        int greenRed = Green + Red;
                        
                        // return value
                        return greenRed;
                    }
                }
                #endregion
                
                #region Index
                /// <summary>
                /// This property gets or sets the value for 'Index'.
                /// </summary>
                public int Index
                {
                    get { return index; }
                    set { index = value; }
                }
                #endregion
                
                #region Red
                /// <summary>
                /// This property gets or sets the value for 'Red'.
                /// </summary>
                public int Red
                {
                    get
                    {
                        // initial value
                        int red = this.Color.R;
    
                        // return value
                        return red;
                    }
                }
                #endregion
                
                #region Total
                /// <summary>
                /// This read only property returns the value for 'Total'.
                /// </summary>
                public int Total
                {
                    get
                    {
                        // initial value
                        int total = Red + Green + Blue;
                        
                        // return value
                        return total;
                    }
                }
                #endregion
                
                #region X
                /// <summary>
                /// This property gets or sets the value for 'X'.
                /// </summary>
                public int X
                {
                    get { return x; }
                    set { x = value; }
                }
                #endregion
                
                #region Y
                /// <summary>
                /// This property gets or sets the value for 'Y'.
                /// </summary>
                public int Y
                {
                    get { return y; }
                    set { y = value; }
                }
                #endregion
                
            #endregion
    
        }
        #endregion
    
    }
    
