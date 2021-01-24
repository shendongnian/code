       [DllImport("Shlwapi.dll", Charset = Charset.Unicode)]
       private static extern int StrCmpLogicalW(string x, string y); 
       
       public ObservableCollection<TestObject> SortObjects(ObservableCollection<TestObject> unsortedObjects){
       var sortedCollection = new ObservableCollection<TestObject>();
       var objectList = new List<TestObject>();
       foreach(var obj in unsortedObjects){
          objectList.Add(obj);
         }
       Comparison<TestObject> typesComp = (a,b) =>{
          var aKey = a.types;
          var bKey = b.types;
          return StrCmpLogicalW(aKey,bKey);
       }
       objectList.Sort(typesComp);
       foreach(var obj in objectList){
         sortedCollection.Add(obj);
       }
       return sortedCollection;
       }
