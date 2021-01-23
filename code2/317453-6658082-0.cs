        public virtual AppContext DeepClone()
        {
            //First do a shallow copy.
            AppContext returnData = (AppContext)this.MemberwiseClone();
            //Get the type.
            Type type = returnData.GetType();
            //Now get all the member variables.
            FieldInfo[] fieldInfoArray = type.GetFields();
            //Deepclone members that extend AppContext.
            //This will ensure we get everything we need.
            foreach (FieldInfo fieldInfo in fieldInfoArray)
            {
                //This gets the actual object in that field.
                object sourceFieldValue = fieldInfo.GetValue(this);
                //See if this member is AppContext
                if (sourceFieldValue is AppContext)
                {
                    //If so, cast as a AppContext.
                    AppContext sourceAppContext = (AppContext)sourceFieldValue;
                    //Create a clone of it.
                    AppContext clonedAppContext = sourceAppContext.DeepClone();
                    //Within the cloned containig class.
                    fieldInfo.SetValue(returnData, clonedAppContext);
                }
            }
            return returnData;
        }
