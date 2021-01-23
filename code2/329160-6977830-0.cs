    public class Word
    {
       private ProgramData _Data
       public Word(ProgramData data)
       {
          _Data = data;
       }
       public void MethodThatUsesData
       {
          // _Data.TryGetValue()
       }
    }
    // in your main method or initialization routine:
    ProgramData data = MethodThatLoadsData();
    Word w = new Word(data);
