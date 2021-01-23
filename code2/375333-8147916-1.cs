    public PropertyDescriptorCollection GetProperties()
    {
       //I need to do something like this:
       if (this.DesignMode)
       { //Expose standart controls properties
           return TypeDescriptor.GetProperties(this, true);
       }
       else
       {   //Forming a custom property descriptor collection
           PropertyDescriptorCollection pdc = new PropertyDescriptorCollection(null);
           //Some code..
           return pdc;      
       }
    }
