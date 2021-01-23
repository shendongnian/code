    public byte[] doSomething() { 
       try {
          var xl = new ExcelWorksheet();
          //...blablabla...
          xl.SaveAs(parameters...);
          if (File.Exists(pathOfXlsDoc)) return File.ReadAllBytes(pathOfXlsDoc);
          return null;
       } finally {
          if (File.Exists) File.Delete(pathOfXlsDoc);
       }
    }
    
    
    ----------
    
