            WorkflowDataContext dataContext = context.DataContext;
            PropertyDescriptorCollection propertyDescriptorCollection = dataContext.GetProperties();
            foreach (PropertyDescriptor propertyDesc in propertyDescriptorCollection)
            {
                if (propertyDesc.Name == "SharedData")
                {
                    myData = propertyDesc.GetValue(dataContext) as Dictionary<string, object>;
                    if (myData == null) //this to check if its the initial(1st) activity.
                        myData = new Dictionary<string, object>();
                    //I'm adding here an additional value into the workflow variable 
                    //its having signature same as that of workflow variable
                    //dictionary's key as what it is and value as an object
                    //which user can cast to what actually one wants.
                    myData.Add("islogonrequired", Boolean.TrueString);
                    //here I'm fetching some value, as i entered it in my previous activity. 
                    string filePath = myData["filepath"].ToString();
                    propertyDesc.SetValue(dataContext, myData);
                    break;
                }
            }
