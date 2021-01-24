    #region using statements
    
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using TransparencyMaker.Objects;
    
    #endregion
    
    namespace TransparencyMaker.Util
    {
    
        #region class DirectBitmap
        /// <summary>
        /// This class is used as a faster alternative to GetPixel and SetPixel
        /// </summary>
        public class DirectBitmap : IDisposable
        {
    
            #region Private Variables
            private History history;
            #endregion
    
            #region Constructor
            /// <summary>
            /// Create a new instance of a 'DirectBitmap' object.
            /// </summary>
            public DirectBitmap(int width, int height)
            {
                Width = width;
                Height = height;
                Bits = new Int32[width * height];
                BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
                Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
            }
            #endregion
            
            #region Methods
                
                #region Dispose()
                /// <summary>
                /// method Dispose
                /// </summary>
                public void Dispose()
                {
                    if (Disposed) return;
                    Disposed = true;
                    Bitmap.Dispose();
                    BitsHandle.Free();
                }
                #endregion
                
                #region GetPixel(int x, int y)
                /// <summary>
                /// method Get Pixel
                /// </summary>
                public Color GetPixel(int x, int y)
                {
                    int index = x + (y * Width);
                    int col = Bits[index];
                    Color result = Color.FromArgb(col);
                    
                    return result;
                }
                #endregion
                
                #region HandleHistory(int x, int y, Guid historyId, Color previousColor)
                /// <summary>
                /// This method Handle History
                /// </summary>
                public void HandleHistory(int x, int y, Guid historyId, Color previousColor)
                {
                    // If the History object exists
                    if ((!this.HasHistory) || (History.Id != historyId) && (historyId != Guid.Empty))
                    {
                        // here a new History object is created and the pixels are added to it instead
                        this.History = new History(historyId);
                    }
    
                    // If the History object exists
                    if (this.HasHistory)
                    {
                        // Create a new instance of a 'PixelInformation' object.
                        PixelInformation pixel = new PixelInformation();
                        pixel.X = x;
                        pixel.Y = y;
                        pixel.Color = previousColor;
    
                        // Add this pixel to history
                        this.History.ChangedPixels.Add(pixel);
                    }
                }
                #endregion
                
                #region SetPixel(int x, int y, Color color)
                /// <summary>
                /// method Set Pixel
                /// </summary>
                public void SetPixel(int x, int y, Color color)
                {
                    int index = x + (y * Width);
                    int col = color.ToArgb();
                    
                    Bits[index] = col;
                }
                #endregion
    
                #region SetPixel(int x, int y, Color color, Guid historyId, Color prevoiusColor)
                /// <summary>
                /// This method Sets a Pixel and it includes a historyId so any changes are stored in history
                /// </summary>
                public void SetPixel(int x, int y, Color color, Guid historyId, Color prevoiusColor)
                {
                    // history has to be set before the pixel is set
                    // Handle the history
                    HandleHistory(x, y, historyId, prevoiusColor);
    
                    int index = x + (y * Width);
                    int col = color.ToArgb();
                    
                    Bits[index] = col;
                }
                #endregion
                
                #region UndoChanges()
                /// <summary>
                /// This method Undo Changes
                /// </summary>
                public void UndoChanges()
                {
                    // If the History object exists
                    if ((this.HasHistory) && (this.History.HasChangedPixels))
                    {
                        // get the changed pixels
                        List<PixelInformation> pixels = this.History.ChangedPixels;
    
                        // Iterate the collection of PixelInformation objects
                        foreach (PixelInformation pixel in pixels)
                        {
                            // for debugging only
                            int alpha = pixel.Color.A;
    
                            // Restore this pixel 
                            SetPixel(pixel.X, pixel.Y, pixel.Color);
                        }
    
                        // Remove the history
                        this.History = null;
                    }
                }
                #endregion
                
            #endregion
            
            #region Properties
                
                #region Bitmap
                /// <summary>
                /// method [Enter Method Description]
                /// </summary>
                public Bitmap Bitmap { get; private set; }
                #endregion
                
                #region Bits
                /// <summary>
                /// method [Enter Method Description]
                /// </summary>
                public Int32[] Bits { get; private set; }
                #endregion
                
                #region BitsHandle
                /// <summary>
                /// This is a ptr to the garbage collector
                /// </summary>
                protected GCHandle BitsHandle { get; private set; }
                #endregion
                
                #region Disposed
                /// <summary>
                /// method [Enter Method Description]
                /// </summary>
                public bool Disposed { get; private set; }
                #endregion
                
                #region HasHistory
                /// <summary>
                /// This property returns true if this object has a 'History'.
                /// </summary>
                public bool HasHistory
                {
                    get
                    {
                        // initial value
                        bool hasHistory = (this.History != null);
                        
                        // return value
                        return hasHistory;
                    }
                }
                #endregion
                
                #region Height
                /// <summary>
                /// method [Enter Method Description]
                /// </summary>
                public int Height { get; private set; }
                #endregion
               
                #region History
                /// <summary>
                /// This property gets or sets the value for 'History'.
                /// </summary>
                public History History
                {
                    get { return history; }
                    set { history = value; }
                }
                #endregion
                
                #region Width
                /// <summary>
                /// method [Enter Method Description]
                /// </summary>
                public int Width { get; private set; }
                #endregion
                
            #endregion
            
        }
        #endregion
    
    }
