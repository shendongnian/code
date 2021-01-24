   public class TextWedge : TextReader
   {
      private StreamReader mSr = null;
      private string mBuffer = "";
      public TextWedge(string filename)
      {
         mSr = File.OpenText(filename);
         // buffer 50
         for (int i =0; i<50; i++)
         {
            mBuffer += (char) (mSr.Read());
         }
      }
      public override int Peek() 
      {
         return mSr.Peek() + mBuffer.Length;
      }
      
      public override int Read()
      {
         int iRet = -1;
         if (mBuffer.Length > 0)
         {
            iRet = mBuffer[0];
            int ic = mSr.Read();
            char c = (char)ic;
            mBuffer = mBuffer.Remove(0, 1);
            if (ic != -1)
            {
               mBuffer += c;
               // Run through the battery of non-xml tags
               mBuffer = mBuffer.Replace("<newline>", "[br]");
            }
         }
         return iRet;
      }
   }
