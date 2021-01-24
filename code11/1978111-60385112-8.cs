    #region using statements
    
    using DataJuggler.Core.UltimateHelper;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    #endregion
    
    namespace TransparencyMaker.Objects
    {
    
        #region class PixelDatabase
        /// <summary>
        /// This class represents a collection of PixelInformation objects
        /// </summary>
        public class PixelDatabase
        {
    
            #region Private Variables
            private List<PixelInformation> pixels;
            #endregion
    
            #region Constructor
            /// <summary>
            /// Create a new instance of a PixelDatabase object
            /// </summary>
            public PixelDatabase()
            {
                // Create a new collection of 'PixelInformation' objects.
                this.Pixels = new List<PixelInformation>();
            }
            #endregion
    
            #region Methods
    
                #region AddPixel(Color color, int x, int y)
                /// <summary>
                /// method returns the Pixel
                /// </summary>
                public PixelInformation AddPixel(Color color, int x, int y)
                {  
                    // Create a pixe
                    PixelInformation pixel = new PixelInformation();
    
                    // Set the color
                    pixel.Color = color;
    
                    // Set the values for x and y
                    pixel.X = x;
                    pixel.Y = y;
    
                    /// The Index is set before the count increments when this item is added
                    pixel.Index = this.Pixels.Count;
    
                    // Add this pixel
                    this.Pixels.Add(pixel);
    
                    // return value
                    return pixel;
                }
                #endregion
                
            #endregion
    
            #region Properties
    
                #region HasOneOrMorePixels
                /// <summary>
                /// This property returns true if this object has one or more 'Pixels'.
                /// </summary>
                public bool HasOneOrMorePixels
                {
                    get
                    {
                        // initial value
                        bool hasOneOrMorePixels = ((this.HasPixels) && (this.Pixels.Count > 0));
                        
                        // return value
                        return hasOneOrMorePixels;
                    }
                }
                #endregion
    
                #region HasPixels
                /// <summary>
                /// This property returns true if this object has a 'Pixels'.
                /// </summary>
                public bool HasPixels
                {
                    get
                    {
                        // initial value
                        bool hasPixels = (this.Pixels != null);
                        
                        // return value
                        return hasPixels;
                    }
                }
                #endregion
                
                #region Pixels
                /// <summary>
                /// This property gets or sets the value for 'Pixels'.
                /// </summary>
                public List<PixelInformation> Pixels
                {
                    get { return pixels; }
                    set { pixels = value; }
                }
                #endregion
                
            #endregion
    
        }
        #endregion
    
    }
    
