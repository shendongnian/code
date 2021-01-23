    public void DisplayItems(EntityCollection<Object> items)
    {
            items.Add(new AnyObjectILike());
            items.Add(new System.Windows.Form());
    }
    EntityCollection<Student> students;  
    DisplayItems((EntityCollection<Object>)  students); //type casting here 
    
