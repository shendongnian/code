    public T CopyObject<T>() where T : new()
    {
        T destination = new T();
        if (destination is BaseCopyObject)
        {
            foreach (var destinationProperty in destination.GetType().GetProperties()) //iterate through the properties of the destination object.
            {
                foreach (var sourceProperty in this.GetType().GetProperties()) // iterate through the properties of the source object to determine if the property names match. If they do, copy the value.
                {
                    //If we have one of our BaseCopyObjects, then set the value with the DeepCopy() method of that object.
                    if (destinationProperty.Name.Equals(sourceProperty.Name))
                    {
                        if (typeof(BaseLibraryClass).IsAssignableFrom(destinationProperty.PropertyType))
                        {
                            BaseCopyObject var = (BaseLibraryClass)sourceProperty.GetValue(this, null);
                            if (var != null)
                            {
                                destinationProperty.SetValue(destination, var.DeepCopy(), null);
                            }
                            break;
                        }
                        //If we have a list, get the list and iterate through the list objects.
                        else if (typeof(IList).IsAssignableFrom(destinationProperty.PropertyType))
                        {
                            IList destinationList = (IList)destinationProperty.GetValue(destination, null);
                            destinationList.Clear();
                            IList sourcelist = (IList)destinationProperty.GetValue(this, null);
                            if (sourcelist != null)
                            {
                                foreach (object listItem in sourcelist)
                                {
                                    if (listItem is Base)
                                    {
                                        BaseLibraryClass n = (BaseLibraryClass)listItem;
                                        destinationList.Add(n);
                                    }
                                }
                            }
                            break;
                        }
                        //Finally we get to normal properties. Set those.
                        else
                        {
                            destinationProperty.SetValue(destination, destinationProperty.GetValue(this, null), null);
                            break;
                        }
                    }
                }
            }
            return destination;
        }
        else
        {
            throw new InvalidOperationException("The destination copy type is not an BaseLibraryClass object");
        }
    }
