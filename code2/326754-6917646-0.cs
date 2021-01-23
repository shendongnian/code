    public void MyButton_Click(object sender, EventArgs e)
    {
         var pageID = MyDal.Instance.GetPageID(someParam);
         this.MyMethod(pageID);
    }
