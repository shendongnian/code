    public void GettingSomeData()
    {
       // … doing something to get / prepare / whatever...
       SomeThingYouWantToExpose = "some new label";
       // Now raise which the view bound to this property will updated itself
       RaisePropertyChanged( "SomeThingYouWantToExpose" );
    }
