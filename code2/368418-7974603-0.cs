    public interface ISpecificAttributeProvider
    {
       object GetSpecificAttribute();
    }
    public class ThirdLevel : SecondLevel, ISpecificAttributeProvider
    {
       private object _attributeInQuestion;
      
       public object GetSpecificAttribute()
       {
          return _attributeInQuestion;
       }
    }
    public class TenthLevel: NinthLevel
    {      
       public void Method()
       {
          if (this is ISpecificAttributeProvider)
             object attribute = GetSpecificAttribute();
       }
    }
