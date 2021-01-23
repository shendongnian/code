    public interface IEditorForm
    {
         void SetItemToEdit(object item);
         object GetModifiedItem();
    }
 
    public class DataModifierFactory
    {
         public Func<IEnumerable<object>> GetData { get; set; }
         public Func<IEditorForm> EditorFormFactory { get; set; }
    }
    //in your code, set up how the types will get handled
    //keep this registration of types and editor info on ObjectSelect form
    Dictionary<Type,DataModifierFactory> myModifiers = new Dictionary<Type,DataModifierFactory>();
    
    Func<IEnumerable<object>> intDataSource = ()=>{ return new int[] { 0,1,2,3 }; };
    Func<IEditorForm> intEditorFormFactory = ()=>new IntEditorForm();
    myModifiers.Add(typeof(int), new DataModifierFactory(){GetData=intDataSource,EditorFormFactory=intEditorFormFactory};
    Func<IEnumerable<object>> stringDataSource = ()=>{ return new string[] { "A","B","C" }; };
    Func<IEditorForm> stringDataFormFactory = ()=>new StringEditorForm();
    myModifiers.Add(typeof(string), new DataModifierFactory(){GetData=stringDataSource,EditorFormFactory=stringDataFormFactor};
    //On object select form
    //this variable is set from above
    Dictionary<Type,DataModifierFactory> m_DataModifierFactoryRegistry;
    IEditorForm m_ItemEditorForm;
    public void ModifyDataOfType<T>()
    {
        DataModifierFactory factory = m_DataModifierFactoryRegistry[typeof(T)];
        myListOfData.Source = factory.GetData();
        m_ItemEditorForm = factory.EditorFormFactory();
    }
    public void OnSelectedItemChanged(object newItem)
    {
        object oldItem = m_ItemEditorForm.GetModifiedItem();
        //save the old item, etc. Possibly another item on DataModiferFactory
        //then set up for the next
        m_ItemEditorForm.SetItemToEdit(newItem);
    }
