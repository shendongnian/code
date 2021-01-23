    foreach(var element in sortedCollection.Keys){
       if(element != null)
       // in this block I would like to assign the element to the properties above
       // ex:
       //foo?? = sortedCollection[element];
       // not sure how you are getting the index here, may be you need to use for loop
       PropertyInfo pi = typeof(MyClass).GetProperty("Foo" + index);
       
       // ?? need to be replaced by index.
       if (pi != null)
       {
           pi.SetValue(<object of MyClass>, sortedCollection[element], null);
       }
    }
