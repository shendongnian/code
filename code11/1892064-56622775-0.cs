    public class A
    {
        // Private internal variables of this class
        List<MyGroup> objMyGrp = new List<MyGroup>();
        int iGrpCount = 0; 
    
        // This method adds a MyGroup instance to the collection
        public void SomeMethod()
        {
             // Some default values. You can pass parameters to this method
             // and then use parameters to initialize the MyGroup instance
             MyGroup grp = new MyGroup();
             grp.RowIndex = 0;
             grp.ColumnIndex = 0;
             grp.ObjectValue = null;
             objMyGrp.Add(grp);
             iGrpCount++;
        }
    
        public void SomeOtherMethod(int grpIndex)
        {
           // Now you could try to change any MyGroup instance stored in the 
           // collection to your desidered rowIndex
           if(grpIndex < iGrpCount)
              objMyGrp[grpIndex].RowIndex = 2;
        }
    }
