    public mainClass{
    
      private ArchiveEntities db;
      private ObservableCollection<Employee> allEmployeesData;
      private Employee selctedEmplyee;
      
      // property in binding
       public ObservableCollection<Employee> AllEmployeesData { get{return allEmployeesData;} set{allEmployeesData=value; onPropertyChanged("AllEmployeesData"); }
       public Employee SelctedEmplyee { get{return selctedEmplyee;} set{selctedEmplyee=value; onPropertyChanged("SelctedEmplyee"); }
    
      mainWindow (){ //Constructor
    
      db=new ArchiveEntities();
      }
    
      private void onedit(){
         new detailWindow(SelectedEmployee).ShowDialog();
         //reload from db, upadte current element  if modified in the detail window
         SelectedEmployee = db.Employees.Single(x => x.Id == SelectedEmployee.Id);
      }
    
      //no need to save in main window (is only for view)
    
    }
    public class detailWindow(){
    
      private ArchiveEntities db;
      private Employee selctedEmplyee;
    
      //employee to modify
      public Employee SelctedEmplyee { get{return selctedEmplyee;} set{selctedEmplyee=value; onPropertyChanged("SelctedEmplyee"); }
    
    
      public detailWindow(Employee SelectedEmployee){
    
        db=new ArchiveEntities; // a new indipendent context
        SelectedEmployee = db.Employees.Single(x => x.Id == SelectedEmployee.Id);
      }
    
      public void onSave(){
        db.SaveChanges(); //effect only in SelectedEmployee
        // if you don'save main window data will not change
      }
    
    
    }
