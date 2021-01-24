    public void KiaMethod(){
      Console.WriteLine("Kia");
    }
    public void BmwMethod(){
      Console.WriteLine("BMW");
    }
    Action method = null;
    if(file.Contains("KIA"))
      method = KiaMethod;
    else if(file.Contains("BMW"))
      method = BmwMethod;
    method();
