    public void DisplayItems(EntityCollection<Object> items)
    {
            //Probably not called add but you get the idea...
            items.Add(new AnyObjectILike());
            items.Add(new System.Windows.Form());
    }
    EntityCollection<Student> students;  
    DisplayItems((EntityCollection<Object>)  students); //type casting here 
    
