     public override bool Equals(object obj)
     {
         if (obj == null || obj.GetType() != GetType())
         {
             return false;
         }
         AbstractDictionaryObject other = (AbstractDictionaryObject)obj;
         return other.LangId == LangId;
     }
     public override int GetHashCode()
     {
         return LangId;
     }
