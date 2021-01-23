    public static MyResultsForm DoShowGetResult()
    {
       var f = new MyForm();
       if(f.ShowDialog() == DialogResult.OK)
       {
          return f.Result;   // public property on your form of the result selected
       }
       return null;
    }
