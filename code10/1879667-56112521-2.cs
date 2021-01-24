    public void EditButton_Clicked(/* Event handlers*/)
    {
        var myObject = this.myObject; // get the object from <somewhere>
        myObject.Name = "abc"; /*set properties
        .
        .
        .
         */
        //at the end of edit, you should call either of these rows to change the time
        myObject.onUpdate(); 
        myObject.DatumPromjene = DateTime.Now; 
    }
