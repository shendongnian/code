         /// <summary>
         /// This method checks whether selected file is Binary file or not.
         /// </summary>     
         public bool CheckForBinary()
         {
            
                 Stream objStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
                 bool bFlag = true;
                 
                 // Iterate through stream & check ASCII value of each byte.
                 for (int nPosition = 0; nPosition < objStream.Length; nPosition++)
                 {
                     int a = objStream.ReadByte();
                     if (!(a >= 0 && a <= 127))
                     {
                         break;            // Binary File
                     }
                     else if (objStream.Position == (objStream.Length))
                     {
                         bFlag = false;    // Text File
                     }
                 }
                 return bFlag;                   
         }
