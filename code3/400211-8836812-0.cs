     change that to be Application _wordApplication = new Application();
    Where you are passing ref paramMissing -- change that to null pass it just like that null
    
    where you are setting the _wordApplication = to null... change it to 
     System.Runtime.InteropServices.Marshal.ReleaseComObject(_wordApplication); 
