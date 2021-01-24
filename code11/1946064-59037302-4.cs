    public ObservableCollection<TestObject> TestObjects = new ObservableCollection<TestObject>();
     TestObjects.Add(new TestObject('708','4','(A)','708.4.(A)'));
     TestObjects.Add(new TestObject('7','41B','1(A)','7.41B.1(A)'));
     TestObjects.Add(new TestObject('69','2','45', '69.2.45'));
     TestObjects.Add(new TestObject('708','4','(B)', '708.4.(B)'));
     TestObjects.Add(new TestObject('69','2','5', '69.2.5'));
     TestObjects.Add(new TestObject('7','41','1(B)', '7.41.1(B)'));
     TestObjects.Add(new TestObject('7','41','', '7.41.'));
      TestObjects= SortObjects(TestObjects);
     
