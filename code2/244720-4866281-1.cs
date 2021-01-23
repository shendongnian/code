    if (myType.IsImplementationOf(typeof(IFormWithWorker)))
    {
        //Do Something
        MessageBox.Show(myType.GetInterface(typeof(DocumentDistributor.Library.IFormWithWorker).FullName).FullName);
    }
    else
    {
        MessageBox.Show("It IS null");
    }
