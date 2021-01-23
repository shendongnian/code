    public testPageNull_shouldThrowArgumentNullException()
    {
        PageWrappable nullPage = new MockPageWrappable();
        nullPage.GetPage().Return(null);
        
        CustomControl sut  = new CustomControl(nullPage);   
 
        Assert.Fail("Exception not thrown");
    }
    public interface PageWrappable
    {
        //Gets Wrapped Page Instance
        WrappedPage GetPage();
        //GetSomethingFromTheForm
        String GetFormValue(String Key);
    }
