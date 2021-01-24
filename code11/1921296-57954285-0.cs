     public class MyViewModel
    {
        public MyViewModel()
        {
            // Sample to pre-load list of records from data server of KVP
            //PickerChoices = GetDataFromServerForDemo("select * from LookupTable where Category = 'demo'");
           PickerChoices = new List<TestModel>() {
                new TestModel{ MyID = 1,ShowValue="test1" }, new TestModel{ MyID = 2,ShowValue="test2" },
                new TestModel{ MyID = 3,ShowValue="test3" }, new TestModel{ MyID = 4,ShowValue="test4" }
            };
            ShowThisRecord = new TestModel();
            // for grins, I am setting the value that SHOULD be defaulted 
            // in picker.  In this case, ID = 12 = "Some Item" from above
            ShowThisRecord.MyID = 12;
        }
        // this is the record that has the "ID" column I am trying to bind to
        public TestModel ShowThisRecord { get; set; }
        // The picker is bound to this list of possible choices
        public List<TestModel> PickerChoices { get; set; }
    }
