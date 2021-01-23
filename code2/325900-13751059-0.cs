        public class Person
        {
           
           public string Name;
           public string LastName;
        
        
        
        }
    
    //This class can be in a separate file
    
    
    //to create a list from this to fill the listbox you can use the following code. 
    
    
    //this can be in the interface part of the app where the value of the selecteditem is selected
    
    Person m = listBoxName.SelectedItem as Person;
    
    string VariableString =  m.Name;
