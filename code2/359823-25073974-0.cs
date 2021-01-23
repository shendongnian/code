    using (Graphics gRef = this.CreateGraphics())  
    {  
        IntPtr hdc = gRef.GetHdc();  
        using (System.Drawing.Imaging.Metafile mf = 
               new System.Drawing.Imaging.Metafile(hdc, 
                    System.Drawing.Imaging.EmfType.EmfPlusDual))  
            {  
              gRef.ReleaseHdc();  
     
              using (Graphics redG = Graphics.FromImage(mf))  
              {  
                redG.SetClip(new RectangleF(...));
    
                // .. draw on redG 
              }  
              // repeat for greenG
    
              // .. save and or combine as desired
    
            }  
        } 
    
    }
