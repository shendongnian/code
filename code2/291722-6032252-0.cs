    generic <typename T>
    public interface class iTest
    {
       public:
       virtual void AddCriteriaList(List<T> ^CriterionList);
    };
    
    generic <typename Q, typename T>
    public ref class IUseInterface : iTest<T>
    {
    public:
       virtual void AddCriteriaList(List<T> ^CriterionList)
       {
       }
    };
