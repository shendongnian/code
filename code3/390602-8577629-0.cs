    namespace TranslationFormsApplication 
    {  
    partial class TranslationForm 
    { 
       public class SavedData 
       { 
          public SavedData(int id, string s, string t) 
          { 
             index = id; 
             source = s; 
             translation = t; 
          } 
          private int m_index; 
          private string m_source; 
          private string m_translation; 
           public int index { get { return m_index; } set { m_index = value; } }
           public string source { get { return m_source; } set { m_source = value; } }
           public string translation { get { return m_translation; } set { m_translation = value; } }
       } 
    } 
    }
