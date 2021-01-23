    class Group
    {
        string Name;
        //pins that belong to this group
        List<string> pins; 
    }
    
    class Device
    {
        string Name;
        //groups that belong to this device
        List<Group> Groups;
    }
   
